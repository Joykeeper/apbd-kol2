using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kol2Preparation.Models;

[Table("Purchased_Ticket")]
[PrimaryKey(nameof(TicketConcertId), nameof(CustomerId))]
public class PurchasedTicket
{
    public int TicketConcertId { get; set; }
    
    public int CustomerId { get; set; }
    
    public DateTime PurchaseDate { get; set; }
    

    [ForeignKey(nameof(TicketConcertId))]
    public virtual TicketConcert TicketConcert { get; set; } = null!;
    
    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; } = null!;
}