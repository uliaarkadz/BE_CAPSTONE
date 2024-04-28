using WebServiceApp.Entities;
using WebServiceApp.Models;
using Product = WebServiceApp.Entities.Product;

namespace WebServiceApp.Services;

public interface IStoreRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<List<Customer>> GetCustomersAsync();
    Task<List<Cart>> GetCartItemsAsync(int customerId);
    Task<List<Order>> GetOrdersAsync(int userId);
    Task<bool> ProductExistsAsync(int productId);
    Task<bool> CustomerExistsAsync(int customerId);
    Task<bool> CartExistsAsync(int productId);
    Task<bool> OrderExistsAsync(int orderId);
    Task<Product?> GetProductAsync(int productId);
    Task<Customer?> GetCustomerAsync(int customerId);
    Task<Cart?> GetCartItemAsync(int cartId);
    Task<Order?> GetOrderAsync(int orderId);
    Task<bool> SaveChangesAsync();
    void AddProduct(Product product);
    void AddCustomer(Customer customer);
    void AddProductCart(Cart cart);
    void AddOrder(Order order);
    void DeleteProduct(Product product);
    void DeleteCustomer(Customer customer);
    void DeleteCart(Cart cart);
    void DeleteOrder(Order order);
    Task DeleteAllCustomerCart(Cart cart, int customerId);

}