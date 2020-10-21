using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RodonavesAPI.Data;
using RodonavesAPI.Models;

namespace RodonavesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly RodonavesAPIContext _context;

        public FornecedoresController(RodonavesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorDTO>>> GetFornecedor()
        {
            return await _context.Fornecedor
                .Include(f => f.FornecedorTelefones)
                .Select(f => FornecedorDTO(f))
                .ToListAsync();
        }

        // GET: api/Fornecedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorDTO>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor
                .Include(f => f.FornecedorTelefones)
                .Where(f => f.Id == id)
                .SingleOrDefaultAsync();

            if (fornecedor == null)
            {
                return NotFound();
            }

            return FornecedorDTO(fornecedor);
        }

        // PUT: api/Fornecedors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor f)
        {
            if (id != f.Id)
            {
                return BadRequest();
            }

            Fornecedor fornecedor = await _context.Fornecedor.FindAsync(id);
            if(fornecedor == null)
            {
                return NotFound();
            }

            fornecedor.RazaoSocial = f.RazaoSocial;
            fornecedor.NomeFantasia = f.NomeFantasia;
            fornecedor.CNPJ = f.CNPJ;
            fornecedor.Endereco = f.Endereco;
            fornecedor.Bairro = f.Bairro;
            fornecedor.CidadeId = f.CidadeId;
            fornecedor.EstadoId = f.EstadoId;
            fornecedor.CEP = f.CEP;
            fornecedor.FornecedorTelefones = f.FornecedorTelefones;
            fornecedor.Inativo = f.Inativo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FornecedorExists(id))
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/Fornecedors
        [HttpPost]
        public async Task<ActionResult> PostFornecedor(Fornecedor fornecedor)
        {

            _context.Fornecedor.Add(new Fornecedor
            {
                RazaoSocial = fornecedor.RazaoSocial,
                NomeFantasia = fornecedor.NomeFantasia,
                CNPJ = fornecedor.CNPJ,
                Endereco = fornecedor.Endereco,
                Bairro = fornecedor.Bairro,
                CidadeId = fornecedor.CidadeId,
                EstadoId = fornecedor.EstadoId,
                CEP = fornecedor.CEP,
                FornecedorTelefones = fornecedor.FornecedorTelefones
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Fornecedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> DeleteFornecedor(int id)
        {
            Fornecedor fornecedor = await _context.Fornecedor.
                Include(f => f.FornecedorTelefones)
                .Where(f => f.Id == id)
                .SingleAsync();

            if (fornecedor == null)
            {
                return NotFound();
            }

            var fornecedorTelefones = _context.FornecedorTelefones.Where(ft => ft.FornecedorId == id);
            _context.FornecedorTelefones.RemoveRange(fornecedorTelefones);

            _context.Fornecedor.Remove(fornecedor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FornecedorExists(id))
            {
                return NotFound();
            }

            return Ok();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(c => c.Id == id);
        }

        private static FornecedorDTO FornecedorDTO(Fornecedor fornecedor)
        {
            return new FornecedorDTO
            {
                Id = fornecedor.Id,
                RazaoSocial = fornecedor.RazaoSocial,
                NomeFantasia = fornecedor.NomeFantasia,
                CNPJ = fornecedor.CNPJ,
                Endereco = fornecedor.Endereco,
                Bairro = fornecedor.Bairro,
                CidadeId = fornecedor.CidadeId,
                EstadoId = fornecedor.EstadoId,
                CEP = fornecedor.CEP,
                FornecedorTelefones = fornecedor.FornecedorTelefones,
                Inativo = fornecedor.Inativo
            };
        }

    }
}
