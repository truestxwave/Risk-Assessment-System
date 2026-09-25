using Microsoft.EntityFrameworkCore;
using Risk.Api.Models;
using Risk.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Risk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskTableController : ControllerBase
    {
        private readonly RiskDbContext _context;

        public RiskTableController(RiskDbContext context)
        {
            _context = context;
        }

        // GET: api/RiskTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Risks>>> GetRisks()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/RiskTable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Risks>> GetRisk(int id)
        {
            var risk = await _context.Projects.FindAsync(id);

            if (risk == null)
            {
                return NotFound();
            }

            return risk;
        }

        // POST: api/RiskTable
        [HttpPost]  
        public async Task<ActionResult<Risks>> PostRisk(Risks risk)
            {
                _context.Projects.Add(risk);
                await _context.SaveChangesAsync();
    
                return CreatedAtAction(
                    nameof(GetRisk), 
                    new { id = risk.Id },
                     risk
                     
                    );
            }

            // PUT: api/RiskTable/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRisk(int id, Risks risk)
        {
            if (id != risk.Id)
            {
                return BadRequest();
            }

            _context.Entry(risk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskExists(id))
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

        // DELETE: api/RiskTable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRisk(int id)
        {
            var risk = await _context.Projects.FindAsync(id);
            if (risk == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(risk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiskExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
