namespace WebServiceApp.Models;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double Price { get; set; } = 0;
    public bool IsProccesed { get; set; }
    public string?  Serial { get; set; }
    public string?  Inventory { get; set; }
    public string?  Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}