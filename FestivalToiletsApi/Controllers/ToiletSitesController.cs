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
    public class ToiletSitesController : ControllerBase
    {
        private readonly FestivalToiletsContext _context;

        public ToiletSitesController(FestivalToiletsContext context)
        {
            _context = context;
        }

        // GET: api/ToiletSites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToiletSite>>> GetToiletSite()
        {
            return await _context.ToiletSite.ToListAsync();
        }

        // GET: api/ToiletSites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToiletSite>> GetToiletSite(long id)
        {
            var toiletSite = await _context.ToiletSite.FindAsync(id);

            if (toiletSite == null)
            {
                return NotFound();
            }

            return toiletSite;
        }

        // PUT: api/ToiletSites/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToiletSite(long id, ToiletSite toiletSite)
        {
            if (id != toiletSite.Id)
            {
                return BadRequest();
            }

            _context.Entry(toiletSite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToiletSiteExists(id))
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

        // POST: api/ToiletSites
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ToiletSite>> PostToiletSite(ToiletSite toiletSite)
        {
            _context.ToiletSite.Add(toiletSite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(toiletSite), new { id = toiletSite.Id }, toiletSite);
        }

        // DELETE: api/ToiletSites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToiletSite>> DeleteToiletSite(long id)
        {
            var toiletSite = await _context.ToiletSite.FindAsync(id);
            if (toiletSite == null)
            {
                return NotFound();
            }

            _context.ToiletSite.Remove(toiletSite);
            await _context.SaveChangesAsync();

            return toiletSite;
        }

        private bool ToiletSiteExists(long id)
        {
            return _context.ToiletSite.Any(e => e.Id == id);
        }
    }
}
