namespace WebServiceApp.Models;

public class CartCreate
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public double TotalAmount { get; set; }
    public int Quantity { get; set; }
    public bool IsProccesed { get; set; }
}