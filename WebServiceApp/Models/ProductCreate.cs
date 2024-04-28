namespace WebServiceApp.Models;
using System.ComponentModel.DataAnnotations;

public class ProductCreate
{
    [Required (ErrorMessage = "You should provide a name value.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Description { get; set; }
    [Required (ErrorMessage = "You should provide price value.")]
    public double Price { get; set; } = 0;
    public bool IsProccesed { get; set; }
    public string?  Serial { get; set; }
    public string?  Inventory { get; set; }
    public string?  Image { get; set; }
}