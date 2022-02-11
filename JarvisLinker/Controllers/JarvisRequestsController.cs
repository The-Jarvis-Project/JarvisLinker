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
    public class JarvisRequestsController : ControllerBase
    {
        private readonly JarvisLinkerContext _context;

        public JarvisRequestsController(JarvisLinkerContext context) => _context = context;

        // GET: api/JarvisRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JarvisRequest>>> GetRequests() =>
            await _context.Requests.ToListAsync();

        // GET: api/JarvisRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JarvisRequest>> GetJarvisRequest(long id)
        {
            var jarvisRequest = await _context.Requests.FindAsync(id);
            if (jarvisRequest == null) return NotFound();
            return jarvisRequest;
        }

        // PUT: api/JarvisRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJarvisRequest(long id, JarvisRequest jarvisRequest)
        {
            if (id != jarvisRequest.Id) return BadRequest();
            _context.Entry(jarvisRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JarvisRequestExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        // POST: api/JarvisRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JarvisRequest>> PostJarvisRequest(JarvisRequest jarvisRequest)
        {
            _context.Requests.Add(jarvisRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetJarvisRequest), new { id = jarvisRequest.Id }, jarvisRequest);
        }

        // DELETE: api/JarvisRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJarvisRequest(long id)
        {
            var jarvisRequest = await _context.Requests.FindAsync(id);
            if (jarvisRequest == null) return NotFound();

            _context.Requests.Remove(jarvisRequest);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool JarvisRequestExists(long id) => _context.Requests.Any(e => e.Id == id);
    }
}
