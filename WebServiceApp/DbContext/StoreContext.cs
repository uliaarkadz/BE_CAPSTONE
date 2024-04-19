
using Microsoft.EntityFrameworkCore;
using WebServiceApp.Entities;



namespace WebServiceApp.DbContext;

public class StoreContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Cart> Cart { get; set; }
    
    public DbSet<Order> Order { get; set; }
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }
    

    
}