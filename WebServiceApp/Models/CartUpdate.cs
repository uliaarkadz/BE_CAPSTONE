namespace WebServiceApp.Models;

public class CartUpdate
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public double TotalAmount { get; set; }
    public int Quantity { get; set; }
}