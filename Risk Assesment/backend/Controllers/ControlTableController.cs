using Microsoft.EntityFrameworkCore;
using Risk.Api.Models;
using Risk.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Controls.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlsTableController : ControllerBase
    {
        private readonly ControlsDbContext _context;

        public ControlsTableController(RiskDbContext context)
        {
            _context = context;
        }

        // GET: api/ControlsTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Controls>>> GetControls()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/ControlsTable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Controls>> GetControls(int id)
        {
            var Controls = await _context.Projects.FindAsync(id);

            if (Controls == null)
            {
                return NotFound();
            }

            return Controls;
        }

        // POST: api/ControlsTable
        [HttpPost]
        public async Task<ActionResult<Controls>> PostControls(Controls controls)
        {
            _context.Projects.Add(controls);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetControls),
                new { id = controls.Id },
                controls
            );
        }

        // PUT: api/ControlsTable/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControls(int id, Controls controls)
        {
            if (id != controls.Id)
            {
                return BadRequest();
            }

            _context.Entry(controls).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlsExists(id))
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

        // DELETE: api/ControlsTable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControls(int id)
        {
            var controls = await _context.Projects.FindAsync(id);
            if (controls == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(controls);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
