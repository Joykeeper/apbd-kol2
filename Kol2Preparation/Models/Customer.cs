using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2Preparation.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    
    public virtual ICollection<PurchasedTicket> PurchasedTickets { get; set; }
}