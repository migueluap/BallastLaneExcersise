using BallastLane.Domain.Models;
using BallastLane.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BallastLane.Infra.Data.Context;

public class BallastLaneContext : DbContext
{
    public BallastLaneContext(DbContextOptions<BallastLaneContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
                    
        base.OnModelCreating(modelBuilder);
    }
}
