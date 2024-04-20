using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServiceApp.Entities;

[Table("orders")]
public class Order
{   
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("cartid")]
    [Required]
    [ForeignKey("cartid")]
    public int CartId { get; set; }
    public Cart Cart { get; set; }
    
    [Column("orderstatus")]
    public string OrderStatus { get; set; }
    
    
}