using Kol2Preparation.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2Preparation.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    public DbSet<Concert> Concert { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchasedTicket>().ToTable("Purchased_Ticket");
        modelBuilder.Entity<TicketConcert>().ToTable("Ticket_Concert");
        
        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>
        {
             new Ticket {
                 TicketId = 1,
                 SerialNumber = "12312312",
                 SeatNumber = 5
             },
             new Ticket {
                 TicketId = 2,
                 SerialNumber = "123123122",
                 SeatNumber = 6
             },
             new Ticket {
                 TicketId = 3,
                 SerialNumber = "13312312",
                 SeatNumber = 7
             },
        });
        
        modelBuilder.Entity<Concert>().HasData(new List<Concert>
        {
            new Concert {
                ConcertId = 1,
                Name = "Concert1",
                Date = new DateTime(2019, 12, 10, 5, 10, 00),
                AvailableTickets = 5
            },
            new Concert {
                ConcertId = 2,
                Name = "Concert2",
                Date = new DateTime(2021, 12, 11, 5, 10, 00),
                AvailableTickets = 5
            },
            new Concert {
                ConcertId = 3,
                Name = "Concert3",
                Date = new DateTime(2020, 12, 12, 5, 10, 00),
                AvailableTickets = 5
            }
        });
        
        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>
        {
            new TicketConcert {
                TicketConcertId = 1,
                TicketId = 1,
                ConcertId = 1,
                Price = 100.5f,
            },
            new TicketConcert {
                TicketConcertId = 2,
                TicketId = 2,
                ConcertId = 2,
                Price = 1200,
            },
            new TicketConcert {
                TicketConcertId = 3,
                TicketId = 3,
                ConcertId = 3,
                Price = 1000,
            },
        });
        
        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer {
                CustomerId = 1,
                FirstName = "Bob",
                LastName = "Hob",
                PhoneNumber = "12312313",
            },
            new Customer {
                CustomerId = 2,
                FirstName = "Jack",
                LastName = "Gob",
                PhoneNumber = "12312318",
            },
        });
        
        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>
        {
            new PurchasedTicket {
                TicketConcertId = 1,
                CustomerId = 1,
                PurchaseDate = new DateTime(2019, 11, 10, 5, 10, 00),
            },
            new PurchasedTicket {
                TicketConcertId = 2,
                CustomerId = 2,
                PurchaseDate = new DateTime(2021, 11, 11, 5, 10, 00),
            },
        });
    }
}