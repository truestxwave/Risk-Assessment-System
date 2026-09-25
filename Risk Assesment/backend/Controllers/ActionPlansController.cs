using Microsoft.EntityFrameworkCore;
using Risk.Api.Models;
using Risk.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace ActionPlans.Api.Controllers
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