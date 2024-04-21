using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebServiceApp.Entities;

[Table("cart")]
public class Cart : BaseEntity
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("customerId")]
    [Required]
    [ForeignKey("customerid")]
    public int CustomerId { get; set; }
    public Customer Customer{ get; set; }

    [Column("productid")]
    [Required]
    [ForeignKey("productid")]
    public int ProductId { get; set; }
    public Product Product{ get; set; }
    
    [Column("totalamount")]
    public double TotalAmount { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }
    
    public ICollection<Order> Orders { get; set; }
 
}
