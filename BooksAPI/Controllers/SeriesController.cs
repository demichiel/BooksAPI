using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksAPI.Data;
using BooksAPI.Models;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly BooksAPIContext _context;

        public SeriesController(BooksAPIContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        public IEnumerable<Serie> GetSerie()
        {
            return _context.Serie.Include(s => s.Books);
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerie([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serie = await _context.Serie.FindAsync(id);

            if (serie == null)
            {
                return NotFound();
            }

            return Ok(serie);
        }

        // PUT: api/Series/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerie([FromRoute] Guid id, [FromBody] Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serie.Id)
            {
                return BadRequest();
            }

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Series
        [HttpPost]
        public async Task<IActionResult> PostSerie([FromBody] Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Serie.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.Id }, serie);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serie = await _context.Serie.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Serie.Remove(serie);
            await _context.SaveChangesAsync();

            return Ok(serie);
        }

        private bool SerieExists(Guid id)
        {
            return _context.Serie.Any(e => e.Id == id);
        }
    }
}