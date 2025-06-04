using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2Preparation.Models;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    [MaxLength(50)]
    public required string SerialNumber { get; set; }

    public int SeatNumber { get; set; }
    
    public virtual ICollection<TicketConcert> TicketConcerts { get; set; }
}