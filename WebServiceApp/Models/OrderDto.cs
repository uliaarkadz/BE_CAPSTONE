using WebServiceApp.Entities;

namespace WebServiceApp.Models;

public class OrderDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public string OrderStatus { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    //public ICollection<Cart> Cart { get; set; } = new List<Cart>();
}