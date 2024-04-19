namespace WebServiceApp.Models;
using System.ComponentModel.DataAnnotations;

public class ProductUpdate
{
    [Required (ErrorMessage = "You should provide a name value.")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Description { get; set; }
    [Required (ErrorMessage = "You should provide price value.")]
    public double Price { get; set; } = 0;
}