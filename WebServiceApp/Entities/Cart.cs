using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebServiceApp.Entities;

[Table("cart")]
public class Cart
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("customerId")]
    [Required]
    [ForeignKey("customerid")]
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }

    [Column("productid")]
    [Required]
    [ForeignKey("productid")]
    public Product? Product { get; set; }
    public int ProductId { get; set; }
    
    [Column("totalamount")]
    public double TotalAmount { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
