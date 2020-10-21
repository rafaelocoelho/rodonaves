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
    public class FornecedorTelefonesController : ControllerBase
    {
        private readonly RodonavesAPIContext _context;

        public FornecedorTelefonesController(RodonavesAPIContext context)
        {
            _context = context;
        }

        // PUT: api/FornecedorTelefones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedorTelefone(int id, FornecedorTelefone fornecedorTelefone)
        {
            if (id != fornecedorTelefone.Id)
            {
                return BadRequest();

            }

            var telefone = _context.FornecedorTelefones.First(t => t.Id == id);
            telefone.Numero = fornecedorTelefone.Numero;            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FornecedorTelefoneExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/FornecedorTelefones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FornecedorTelefone>> DeleteFornecedorTelefone(int id)
        {
            var fornecedorTelefone = await _context.FornecedorTelefones.FindAsync(id);
            if (fornecedorTelefone == null)
            {
                return NotFound();
            }

            _context.FornecedorTelefones.Remove(fornecedorTelefone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorTelefoneExists(int id)
        {
            return _context.FornecedorTelefones.Any(e => e.Id == id);
        }
    }
}
