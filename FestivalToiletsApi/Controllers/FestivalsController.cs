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
    public class FestivalsController : ControllerBase
    {
        private readonly FestivalToiletsContext _context;

        public FestivalsController(FestivalToiletsContext context)
        {
            _context = context;
        }

        // GET: api/Festivals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festival>>> Getfestivals()
        {
            return await _context.festivals.ToListAsync();
        }

        // GET: api/Festivals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Festival>> GetFestival(long id)
        {
            var festival = await _context.festivals.FindAsync(id);

            if (festival == null)
            {
                return NotFound();
            }

            return festival;
        }

        // PUT: api/Festivals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFestival(long id, Festival festival)
        {
            if (id != festival.Id)
            {
                return BadRequest();
            }

            _context.Entry(festival).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalExists(id))
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

        // POST: api/Festivals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Festival>> PostFestival(Festival festival)
        {
            _context.festivals.Add(festival);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(festival), new { id = festival.Id }, festival);
        }

        // DELETE: api/Festivals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Festival>> DeleteFestival(long id)
        {
            var festival = await _context.festivals.FindAsync(id);
            if (festival == null)
            {
                return NotFound();
            }

            _context.festivals.Remove(festival);
            await _context.SaveChangesAsync();

            return festival;
        }

        private bool FestivalExists(long id)
        {
            return _context.festivals.Any(e => e.Id == id);
        }
    }
}
