using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2Preparation.Models;

[Table("TableName")]
public class MockModel
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public required string FirstName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    
    // in case 1 to many connection
    // public virtual ICollection<Prescription> Prescriptions { get; set; }
    
    //in case FK
    // [Key]
    // public int ClientId { get; set; }
    // [ForeignKey(nameof(ClientId))]
    // public virtual Client Client { get; set; }

}