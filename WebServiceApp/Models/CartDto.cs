using WebServiceApp.Entities;

namespace WebServiceApp.Models;

public class CartDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public double TotalAmount { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}