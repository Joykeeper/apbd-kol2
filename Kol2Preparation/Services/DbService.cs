using Kol2Preparation.Data;
using Kol2Preparation.DTOs;
using Kol2Preparation.Exceptions;
using Kol2Preparation.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2Preparation.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<object> GetCustomerData(int id)
    {
        var customer = await _context.Customers
            .Where(c => c.CustomerId == id)
            .Select(c => new CustomerDto()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Purchases = c.PurchasedTickets
                    .Select(pr => new PurchaseDto()
                    {
                        Date = pr.PurchaseDate,
                        Price = pr.TicketConcert.Price,
                        Ticket = new TicketDto()
                        {
                            Serial = pr.TicketConcert.Ticket.SerialNumber,
                            SeatNumber = pr.TicketConcert.Ticket.SeatNumber,
                        },
                        Concert = new ConcertDto()
                        {
                            Name = pr.TicketConcert.Concert.Name,
                            Date = pr.TicketConcert.Concert.Date,
                        }
                    }).ToList(),
            }).FirstOrDefaultAsync();

        if (customer == null)
        {
            throw new NotFoundException("Customer not found");
        }

        return customer;
    }

    public async Task AddCustomerData(DataDto data)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var customer = await _context.Customers
                .Where(c => c.CustomerId == data.Customer.Id)
                .FirstOrDefaultAsync();

            if (customer != null)
            {
                customer = new Customer()
                {
                    CustomerId = data.Customer.Id,
                    FirstName = data.Customer.FirstName,
                    LastName = data.Customer.LastName,
                    PhoneNumber = data.Customer.PhoneNumber,
                };
            }

            if (data.Purchases.Count > 5)
            {
                    throw new BadRequestException("Customer cannot have more than 5 tickets on the concert");
            }

            foreach (var concert in data.Purchases)
            {
                if (await DoesConcertExist(concert.ConcertName) == false)
                {
                    throw new BadRequestException("Concert doesn't exist");
                }
            }

            int seats = 1;
            

            foreach (var concert in data.Purchases)
            {
                var newTicket = new Ticket()
                {
                    SerialNumber = "dasdasdasd",
                    SeatNumber = seats++
                };
                var c =  await _context.Concert
                    .Where(c => c.Name == concert.ConcertName)
                    .FirstOrDefaultAsync();
                var newConcert = new TicketConcert()
                {
                    TicketId = newTicket.TicketId,
                    ConcertId = c.ConcertId,
                    Price = concert.Price,
                };

                var newPurchase = new PurchasedTicket()
                {
                    TicketConcertId = newConcert.TicketConcertId,
                    CustomerId = data.Customer.Id,
                    PurchaseDate = DateTime.Now
                };
                
                await _context.Tickets.AddAsync(newTicket);
                await _context.TicketConcerts.AddAsync(newConcert);
                await _context.PurchasedTickets.AddAsync(newPurchase);

            }

            await _context.SaveChangesAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
        
    }

    public async Task<bool> DoesConcertExist(string concert)
    {
        var concert2 = await _context.Concert
            .Where(c => c.Name == concert)
            .FirstOrDefaultAsync();
        return concert2 != null;
    }
}