using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServiceApp.Entities;

[Table("users")]
public class User : BaseEntity
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("username")]
    [Required]
    public int UserName { get; set; }
    
    [Column("password")]
    [Required]
    public int Password { get; set; }
    
    [Column("customerid")]
    [ForeignKey("customerid")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
}