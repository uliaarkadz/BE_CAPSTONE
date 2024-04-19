using Microsoft.EntityFrameworkCore;
using WebServiceApp.DbContext;
using WebServiceApp.Entities;

namespace WebServiceApp.Services;

public class StoreRepository : IStoreRepository
{
    private readonly StoreContext _context;

    public StoreRepository(StoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Product.OrderBy(c => c.Name).ToListAsync();
    }
    
    public async Task<bool>ProductExistsAsync(int productId)
    {
        return await _context.Product.AnyAsync(c => c.Id == productId);
    }
    
    public async Task<Product?> GetProductAsync(int productId)
    {
        return await _context.Product.Where(c => c.Id == productId).FirstOrDefaultAsync();
    }
    
    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _context.Customer.OrderBy(c => c.LastName).ToListAsync();
    }
    
    public async Task<bool>CustomerExistsAsync(int customerId)
    {
        return await _context.Customer.AnyAsync(c => c.Id == customerId);
    }
    
    public async Task<Customer?> GetCustomerAsync(int custommerId)
    {
        return await _context.Customer.Where(c => c.Id == custommerId).FirstOrDefaultAsync();
    }
    
    public async Task<List<Cart>> GetCartItemsAsync(int customerId)
    {
        return await _context.Cart.Where(c => c.Id == customerId).ToListAsync();
    }
    
    public async Task<bool>CartExistsAsync(int productId)
    {
        return await _context.Product.AnyAsync(c => c.Id == productId);
    }
    
    public async Task<Cart?> GetCartItemAsync(int cartId)
    {
        return await _context.Cart.Where(c => c.Id == cartId).FirstOrDefaultAsync();
    }
    
    public void AddProduct(Product product)
    {
        _context.Add(product);
    }
    
    public void AddCustomer(Customer customer)
    {
        _context.Add(customer);
    }
    
    public async Task AddProductCart(int cartId,Product product)
    {
        var cart = await GetCartItemAsync(cartId);
        cart?.Products.Add(product);
    }
    public void DeleteProduct(Product product)
    {
        _context.Remove(product);
    }
    
    public void DeleteCustomer(Customer customer)
    {
        _context.Remove(customer);
    }
    
    public void DeleteCart(Cart cart)
    {
        _context.Remove(cart);
    }
    
    public async Task DeleteAllCustomerCart(Cart cart, int customerId)
    {
        var customers = await GetCartItemsAsync(customerId);
        
        _context.Cart.RemoveRange(customers.Where(x=>x.CustomerId ==customerId));
        
       /* foreach (var item in customers)
        { 
            _context.Cart.RemoveRange(item);
        }*/
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
    
}