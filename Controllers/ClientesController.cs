using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RodonavesAPI.Data;
using RodonavesAPI.Models;

namespace RodonavesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly RodonavesAPIContext _context;

        public ClientesController(RodonavesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetCliente()
        {
            var clientes = await _context.Cliente
                .Include(c => c.ClienteTelefones)
                .Select(c => ClienteDTO(c))
                .ToListAsync();

            return clientes;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _context.Cliente
                .Include(c => c.ClienteTelefones)
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return ClienteDTO(cliente);
                 
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente c)
        {
            if (id != c.Id)
            {
                return BadRequest();
            }

            Cliente cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Id = cliente.Id;
            cliente.NomeCompleto = cliente.NomeCompleto;
            cliente.CPF = cliente.CPF;
            cliente.Endereco = cliente.Endereco;
            cliente.Bairro = cliente.Bairro;
            cliente.CidadeId = cliente.CidadeId;
            cliente.EstadoId = cliente.EstadoId;
            cliente.CEP = cliente.CEP;
            cliente.ClienteTelefones = cliente.ClienteTelefones;
            cliente.Inativo = cliente.Inativo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when(!ClienteExists(id))
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult> PostCliente(Cliente cliente)
        {
            _context.Cliente.Add(new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                CPF = cliente.CPF,
                Endereco = cliente.Endereco,
                Bairro = cliente.Bairro,
                CidadeId = cliente.CidadeId,
                EstadoId = cliente.EstadoId,
                CEP = cliente.CEP,
                ClienteTelefones = cliente.ClienteTelefones
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente
                .Include(c => c.ClienteTelefones)
                .Where(c => c.Id == id)
                .SingleAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteTelefones = _context.ClienteTelefones.Where(ct => ct.ClienteId == id);
            _context.ClienteTelefones.RemoveRange(clienteTelefones);

            _context.Cliente.Remove(cliente);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ClienteExists(id))
            {
                return NotFound();
            }

            return Ok();
        }

        private bool ClienteExists(int id) =>
            _context.Cliente.Any(c => c.Id == id);

        private static ClienteDTO ClienteDTO(Cliente cliente)
        {
            return new ClienteDTO
            {
                Id = cliente.Id,
                NomeCompleto = cliente.NomeCompleto,
                CPF = cliente.CPF,
                Endereco = cliente.Endereco,
                Bairro = cliente.Bairro,
                CidadeId = cliente.CidadeId,
                EstadoId = cliente.EstadoId,
                CEP = cliente.CEP,
                ClienteTelefones = cliente.ClienteTelefones,
                Inativo = cliente.Inativo
            };
        }
    }
}
