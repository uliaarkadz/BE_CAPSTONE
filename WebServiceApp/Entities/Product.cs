namespace WebServiceApp.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("products")]
public class Product
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("name")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Column("description")]
    [MaxLength(500)]
    public string?  Description { get; set; }
    
    [Column("price")]
    [MaxLength(500)]
    public double? Price { get; set; }
    
    public ICollection<Cart> Carts { get; set; }
    public Product(string name)
    {
        Name = name;
    }
}