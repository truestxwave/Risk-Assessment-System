using Microsoft.EntityFrameworkCore;
using Risk.Api.Models;
using Risk.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsTableController : ControllerBase
    {
        private readonly RiskDbContext _context;

        public IncidentsTableController(RiskDbContext context)
        {
            _context = context;
        }

        // GET: api/IncidentsTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidents>>> GetIncidents()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/IncidentsTable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incidents>> GetIncident(int id)
        {
            var incident = await _context.Projects.FindAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // POST: api/IncidentsTable
        [HttpPost]  
        public async Task<ActionResult<Incidents>> PostIncident(Incidents incident)
            {
                _context.Projects.Add(incident);
                await _context.SaveChangesAsync();
    
                return CreatedAtAction(
                    nameof(GetIncident), 
                    new { id = incident.Id },
                     incident
                     
                    );
            }

            // PUT: api/IncidentsTable/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(int id, Incidents incident)
        {
            if (id != incident.Id)
            {
                return BadRequest();
            }

            _context.Entry(incident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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


        // DELETE: api/IncidentsTable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(int id)
        {
            var incident = await _context.Projects.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(incident);
            await _context.SaveChangesAsync();

            return NoContent();
        }   

        private bool IncidentExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }

    }
}
