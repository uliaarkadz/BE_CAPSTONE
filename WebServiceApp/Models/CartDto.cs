using WebServiceApp.Entities;

namespace WebServiceApp.Models;

public class CartDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public double TotalAmount { get; set; }
    public int Quantity { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}