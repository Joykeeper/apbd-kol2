using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2Preparation.Models;

[Table("Concert")]
public class Concert
{
    [Key]
    public int ConcertId { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }

    public DateTime Date { get; set; }

    public int AvailableTickets { get; set; }
    
    public virtual ICollection<TicketConcert> TicketConcerts { get; set; }

}