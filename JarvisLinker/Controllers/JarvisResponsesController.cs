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
    public class JarvisResponsesController : ControllerBase
    {
        private readonly JarvisLinkerContext _context;

        public JarvisResponsesController(JarvisLinkerContext context) => _context = context;

        // GET: api/JarvisResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JarvisResponse>>> GetJarvisResponse() =>
            await _context.Responses.ToListAsync();

        // GET: api/JarvisResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JarvisResponse>> GetJarvisResponse(long id)
        {
            var jarvisResponse = await _context.Responses.FindAsync(id);
            if (jarvisResponse == null) return NotFound();
            return jarvisResponse;
        }

        // PUT: api/JarvisResponses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJarvisResponse(long id, JarvisResponse jarvisResponse)
        {
            if (id != jarvisResponse.Id) return BadRequest();
            _context.Entry(jarvisResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JarvisResponseExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        // POST: api/JarvisResponses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JarvisResponse>> PostJarvisResponse(JarvisResponse jarvisResponse)
        {
            _context.Responses.Add(jarvisResponse);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetJarvisResponse), new { id = jarvisResponse.Id }, jarvisResponse);
        }

        // DELETE: api/JarvisResponses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJarvisResponse(long id)
        {
            var jarvisResponse = await _context.Responses.FindAsync(id);
            if (jarvisResponse == null) return NotFound();

            _context.Responses.Remove(jarvisResponse);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool JarvisResponseExists(long id) => _context.Responses.Any(e => e.Id == id);
    }
}
