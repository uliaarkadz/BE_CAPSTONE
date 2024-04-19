using WebServiceApp.Entities;
using WebServiceApp.Models;
using Product = WebServiceApp.Entities.Product;

namespace WebServiceApp.Services;

public interface IStoreRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<List<Customer>> GetCustomersAsync();
    
    Task<List<Cart>> GetCartItemsAsync(int customerId);
    
    Task<bool> ProductExistsAsync(int productId);
    Task<bool> CustomerExistsAsync(int customerId);
    Task<bool> CartExistsAsync(int productId);
    Task<Product?> GetProductAsync(int productId);
    Task<Customer?> GetCustomerAsync(int customerId);
    Task<Cart?> GetCartItemAsync(int cartId);
    Task<bool> SaveChangesAsync();
    void AddProduct(Product product);
    void AddCustomer(Customer customer);
    Task AddProductCart(int cartId, Product product);
    void DeleteProduct(Product product);
    void DeleteCustomer(Customer customer);
    void DeleteCart(Cart cart);
    Task DeleteAllCustomerCart(Cart cart, int customerId);

}