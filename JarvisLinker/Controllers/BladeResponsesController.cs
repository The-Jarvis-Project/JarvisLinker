using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JarvisLinker.Models;

namespace JarvisLinker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BladeResposesController : ControllerBase
    {
        private readonly JarvisLinkerContext _context;

        public BladeResposesController(JarvisLinkerContext context) => _context = context;

        // GET: api/BladeResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BladeMsg>>> GetBladeResponses() =>
            await _context.BladeResponses.ToListAsync();

        // GET: api/BladeResponses/demo
        [HttpGet("{id}")]
        public async Task<ActionResult<BladeMsg>> GetBladeResponse(string id)
        {
            var bladeResponse = await _context.BladeResponses.FindAsync(id);
            if (bladeResponse == null) return NotFound();
            return bladeResponse;
        }

        // PUT: api/BladeResponses/demo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBladeResponse(string id, BladeMsg bladeResponse)
        {
            if (id != bladeResponse.Origin) return BadRequest();
            _context.Entry(bladeResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BladeResponseExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        // POST: api/BladeResponses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BladeMsg>> PostBladeResponse(BladeMsg bladeResponse)
        {
            _context.BladeResponses.Add(bladeResponse);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBladeResponse), new { id = bladeResponse.Origin }, bladeResponse);
        }

        // DELETE: api/BladeResponses/demo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBladeResponse(string id)
        {
            var bladeResponse = await _context.BladeResponses.FindAsync(id);
            if (bladeResponse == null) return NotFound();

            _context.BladeResponses.Remove(bladeResponse);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BladeResponseExists(string id) => _context.BladeResponses.Any(e => e.Origin == id);
    }
}
