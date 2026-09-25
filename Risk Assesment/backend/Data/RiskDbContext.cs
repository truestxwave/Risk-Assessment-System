using Microsoft.EntityFrameworkCore;
using Risk.Api.Models;

namespace Risk.Api.Data
{
    public class RiskDbContext : DbContext
    {
        public RiskDbContext(DbContextOptions<RiskDbContext> options) : base(options) { }

        public DbSet<Risks> Projects { get; set; } = null!;

        public DbSet<Controls> RiskTypes { get; set; } = null!;

        public DbSet<Incidents> Incidents { get; set; } = null!;

        public DbSet<ActionPlans> ActionPlans { get; set; } = null!;
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        
           
    }
}
}
