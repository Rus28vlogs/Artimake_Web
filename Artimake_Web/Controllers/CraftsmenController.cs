using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Artimake_Web.Data;
using Artimake_Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Artimake_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraftsmenController : ControllerBase
    {
        private readonly ArtimakeDbContext _context;

        public CraftsmenController(ArtimakeDbContext context)
        {
            _context = context;
        }

        // GET: api/Craftsmen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Craftsman>>> GetCraftsmen()
        {
            return await _context.Craftsmen.ToListAsync();
        }

        // GET: api/Craftsmen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Craftsman>> GetCraftsman(int id)
        {
            var craftsman = await _context.Craftsmen.FindAsync(id);

            if (craftsman == null)
            {
                return NotFound();
            }

            return craftsman;
        }

        // PUT: api/Craftsmen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCraftsman(int id, Craftsman craftsman)
        {
            if (id != craftsman.CraftsmanId)
            {
                return BadRequest();
            }

            _context.Entry(craftsman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CraftsmanExists(id))
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

        // POST: api/Craftsmen
        [HttpPost]
        public async Task<ActionResult<Craftsman>> CreateCraftsman(Craftsman craftsman)
        {
            _context.Craftsmen.Add(craftsman);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCraftsman), new { id = craftsman.CraftsmanId }, craftsman);
        }

        // DELETE: api/Craftsmen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCraftsman(int id)
        {
            var craftsman = await _context.Craftsmen.FindAsync(id);
            if (craftsman == null)
            {
                return NotFound();
            }

            _context.Craftsmen.Remove(craftsman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CraftsmanExists(int id)
        {
            return _context.Craftsmen.Any(e => e.CraftsmanId == id);
        }
    }
}
