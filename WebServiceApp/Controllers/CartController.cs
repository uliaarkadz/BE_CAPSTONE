using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServiceApp.Models;
using WebServiceApp.Services;

namespace WebServiceApp.Controllers;
[ApiController]
[Route("api/cart/{customerId:int}")]
public class CartController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    
    public CartController(IStoreRepository storeRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartDto>>> GetCustomerCartItems(int customerId)
    {
        var cartEntities = await _storeRepository.GetCartItemsAsync(customerId);

        return Ok(_mapper.Map<IEnumerable<CartDto>>(cartEntities));
    }
    
    [HttpGet("{id:int}/", Name = "GetCart")]
    public async Task<IActionResult> GetCustomerCartItem(int id)
    {
        if (!await _storeRepository.CartExistsAsync(id))
        {
            return NotFound();
        }
        var cartItem = await _storeRepository.GetCartItemAsync(id);
        
        return Ok(_mapper.Map<CartDto>(cartItem));
    }
    
    [HttpPost]
    public async Task<ActionResult<CartDto>> AddCustomerCartItem(int customerId,
        CartCreate cartCreate)
    {
        var product = await _storeRepository.GetProductAsync(cartCreate.ProductId);
        
        var total = product.Price * cartCreate.Quantity;
        
        cartCreate.CustomerId = customerId;
        cartCreate.TotalAmount = (double)total;
        
        var createdCart = _mapper.Map<Entities.Cart>(cartCreate);
        _storeRepository.AddProductCart(createdCart);
        await _storeRepository.SaveChangesAsync();
        var createdCartReturn = _mapper.Map<CartDto>(createdCart);
        
        return CreatedAtRoute("GetCart",
            new
            {
                customerId = createdCartReturn.CustomerId,
                id = createdCartReturn.Id
            }, createdCartReturn.Id);
    }
}