using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebServiceApp.Entities;

[Table("customers")]
public class Customer()
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("firstname")]
    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Column("lastname")]
    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Column("dob")]
    [Required]
    public DateOnly DateOfBirth { get; set; }
    
    [Column("addressone")]
    [MaxLength(50)]
    public string? Address1 { get; set; }
    
    [Column("addresstwo")]
    [MaxLength(50)]
    public string? Address2 { get; set; }
    
    [Column("city")]
    [MaxLength(20)]
    public string? City { get; set; }
    
    [Column("state")]
    [MaxLength(2)]
    public string? State { get; set; }
    
    [Column("zip")]
    [MaxLength(5)]
    public string? Zip { get; set; }

    //public ICollection<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();

}