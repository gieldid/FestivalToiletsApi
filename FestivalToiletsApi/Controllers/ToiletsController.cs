using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestivalToiletsApi.Models;

namespace FestivalToiletsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToiletsController : ControllerBase
    {
        private readonly FestivalToiletsContext _context;

        public ToiletsController(FestivalToiletsContext context)
        {
            _context = context;
        }

        // GET: api/Toilets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toilet>>> GetToilet()
        {
            return await _context.Toilet.ToListAsync();
        }

        // GET: api/Toilets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toilet>> GetToilet(long id)
        {
            var toilet = await _context.Toilet.FindAsync(id);

            if (toilet == null)
            {
                return NotFound();
            }

            return toilet;
        }

        // PUT: api/Toilets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToilet(long id, Toilet toilet)
        {
            if (id != toilet.Id)
            {
                return BadRequest();
            }

            _context.Entry(toilet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToiletExists(id))
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

        // POST: api/Toilets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Toilet>> PostToilet(Toilet toilet)
        {
            _context.Toilet.Add(toilet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(toilet), new { id = toilet.Id }, toilet);
        }

        // DELETE: api/Toilets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Toilet>> DeleteToilet(long id)
        {
            var toilet = await _context.Toilet.FindAsync(id);
            if (toilet == null)
            {
                return NotFound();
            }

            _context.Toilet.Remove(toilet);
            await _context.SaveChangesAsync();

            return toilet;
        }

        private bool ToiletExists(long id)
        {
            return _context.Toilet.Any(e => e.Id == id);
        }
    }
}
