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
    public class ProductPhotosController : ControllerBase
    {
        private readonly ArtimakeDbContext _context;

        public ProductPhotosController(ArtimakeDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductPhotos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPhoto>>> GetProductPhotos()
        {
            return await _context.ProductPhotos
                                 .Include(pp => pp.Product)
                                 .ToListAsync();
        }

        // GET: api/ProductPhotos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPhoto>> GetProductPhoto(int id)
        {
            var productPhoto = await _context.ProductPhotos
                                             .Include(pp => pp.Product)
                                             .FirstOrDefaultAsync(pp => pp.PhotoId == id);

            if (productPhoto == null)
            {
                return NotFound();
            }

            return productPhoto;
        }

        // PUT: api/ProductPhotos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPhoto(int id, ProductPhoto productPhoto)
        {
            if (id != productPhoto.PhotoId)
            {
                return BadRequest();
            }

            _context.Entry(productPhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPhotoExists(id))
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

        // POST: api/ProductPhotos
        [HttpPost]
        public async Task<ActionResult<ProductPhoto>> PostProductPhoto(ProductPhoto productPhoto)
        {
            _context.ProductPhotos.Add(productPhoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductPhoto", new { id = productPhoto.PhotoId }, productPhoto);
        }

        // DELETE: api/ProductPhotos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPhoto(int id)
        {
            var productPhoto = await _context.ProductPhotos.FindAsync(id);
            if (productPhoto == null)
            {
                return NotFound();
            }

            _context.ProductPhotos.Remove(productPhoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductPhotoExists(int id)
        {
            return _context.ProductPhotos.Any(e => e.PhotoId == id);
        }
    }
}
