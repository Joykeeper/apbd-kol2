using Kol2Preparation.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2Preparation.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    // public DbSet<Pastry> Pastries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<OrderPastry>().ToTable("Order_Pastry");
        
        // modelBuilder.Entity<Employee>().HasData(new List<Employee>
        // {
        //     new Employee {
        //         Id = 1,
        //         FirstName = "Adam",
        //         LastName = "Nowak"
        //     },
        //     new Employee {
        //         Id = 2,
        //         FirstName = "Aleksandra",
        //         LastName = "Wiśniewska"
        //     }
        // });
    }
}