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
    public class ClienteTelefonesController : ControllerBase
    {
        private readonly RodonavesAPIContext _context;

        public ClienteTelefonesController(RodonavesAPIContext context)
        {
            _context = context;
        }

        // PUT: api/ClienteTelefones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteTelefone(int id, ClienteTelefone clienteTelefone)
        {
            if (id != clienteTelefone.Id)
            {
                return BadRequest();
            }

            var telefone = _context.ClienteTelefones.First(t => t.Id == id);
            telefone.Numero = clienteTelefone.Numero;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ClienteTelefoneExists(id))
            {
                return NotFound();                
            }

            return NoContent();
        }

        // DELETE: api/ClienteTelefones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteTelefone>> DeleteClienteTelefone(int id)
        {
            var clienteTelefone = await _context.ClienteTelefones.FindAsync(id);
            if (clienteTelefone == null)
            {
                return NotFound();
            }

            _context.ClienteTelefones.Remove(clienteTelefone);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ClienteTelefoneExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool ClienteTelefoneExists(int id)
        {
            return _context.ClienteTelefones.Any(e => e.Id == id);
        }
    }
}
