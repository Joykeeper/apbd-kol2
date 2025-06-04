using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kol2Preparation.Models;

[Table("Ticket_Concert")]
public class TicketConcert
{
    [Key]
    public int TicketConcertId { get; set; }
    
    public int TicketId { get; set; }
    public int ConcertId { get; set; }

    [DataType("decimal")]
    [Precision(10, 2)]
    public double Price { get; set; }
    
    public virtual ICollection<PurchasedTicket> PurchasedTickets { get; set; }
    
    [ForeignKey(nameof(TicketId))]
    public virtual Ticket Ticket { get; set; } = null!;
    
    [ForeignKey(nameof(ConcertId))]
    public virtual Concert Concert { get; set; } = null!;
}