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
    public class BladeCommandsController : ControllerBase
    {
        private readonly JarvisLinkerContext _context;

        public BladeCommandsController(JarvisLinkerContext context) => _context = context;

        // GET: api/BladeCommands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BladeMsgCmd>>> GetCommands() =>
            await _context.BladeCommands.ToListAsync();

        // GET: api/BladeCommands/demo
        [HttpGet("{id}")]
        public async Task<ActionResult<BladeMsgCmd>> GetBladeCmd(string id)
        {
            var bladeCmd = await _context.BladeCommands.FindAsync(id);
            if (bladeCmd == null) return NotFound();
            return bladeCmd;
        }

        // PUT: api/BladeCommands/demo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBladeCmd(string id, BladeMsgCmd bladeCmd)
        {
            if (id != bladeCmd.Origin) return BadRequest();
            _context.Entry(bladeCmd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BladeCmdExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        // POST: api/BladeCommands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BladeMsgCmd>> PostBladeCmd(BladeMsgCmd bladeCmd)
        {
            _context.BladeCommands.Add(bladeCmd);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBladeCmd), new { id = bladeCmd.Origin }, bladeCmd);
        }

        // DELETE: api/BladeCommands/demo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBladeCmd(string id)
        {
            var bladeCmd = await _context.BladeCommands.FindAsync(id);
            if (bladeCmd == null) return NotFound();

            _context.BladeCommands.Remove(bladeCmd);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BladeCmdExists(string id) => _context.BladeCommands.Any(e => e.Origin == id);
    }
}
