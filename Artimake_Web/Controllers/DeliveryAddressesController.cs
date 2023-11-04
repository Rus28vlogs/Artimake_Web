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
    public class DeliveryAddressesController : ControllerBase
    {
        private readonly ArtimakeDbContext _context;

        public DeliveryAddressesController(ArtimakeDbContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryAddress>>> GetDeliveryAddresses()
        {
            return await _context.DeliveryAddresses.ToListAsync();
        }

        // GET: api/DeliveryAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryAddress>> GetDeliveryAddress(int id)
        {
            var deliveryAddress = await _context.DeliveryAddresses.FindAsync(id);

            if (deliveryAddress == null)
            {
                return NotFound();
            }

            return deliveryAddress;
        }

        // PUT: api/DeliveryAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryAddress(int id, DeliveryAddress deliveryAddress)
        {
            if (id != deliveryAddress.AddressId)
            {
                return BadRequest();
            }

            _context.Entry(deliveryAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryAddressExists(id))
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

        // POST: api/DeliveryAddresses
        [HttpPost]
        public async Task<ActionResult<DeliveryAddress>> PostDeliveryAddress(DeliveryAddress deliveryAddress)
        {
            _context.DeliveryAddresses.Add(deliveryAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryAddress", new { id = deliveryAddress.AddressId }, deliveryAddress);
        }

        // DELETE: api/DeliveryAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryAddress(int id)
        {
            var deliveryAddress = await _context.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            _context.DeliveryAddresses.Remove(deliveryAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryAddressExists(int id)
        {
            return _context.DeliveryAddresses.Any(e => e.AddressId == id);
        }
    }
}
