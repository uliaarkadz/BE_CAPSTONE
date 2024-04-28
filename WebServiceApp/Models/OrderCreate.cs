namespace WebServiceApp.Models;

public class OrderCreate
{
    public int CartID { get; set; }
    public string OrderStatus { get; set; }
    public string UserId { get; set; }
}