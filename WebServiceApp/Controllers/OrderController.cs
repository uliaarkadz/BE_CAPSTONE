using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServiceApp.Models;
using WebServiceApp.Services;

namespace WebServiceApp.Controllers;

[ApiController]
[Route("api/order/")]

public class OrderController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    
    public OrderController(IStoreRepository storeRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    
    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(int userId)
    {
        var orderEntities = await _storeRepository.GetOrdersAsync(userId);

        return Ok(_mapper.Map<IEnumerable<OrderDto>>(orderEntities));
    }
    
    [HttpGet("{id:int}", Name = "GetOrder")]
    public async Task<IActionResult> GetOrder(int id)
    {
        if (!await _storeRepository.OrderExistsAsync(id))
        {
            return NotFound();
        }
        var orderItem = await _storeRepository.GetOrderAsync(id);
        
        return Ok(_mapper.Map<OrderDto>(orderItem));
    }
    
    [HttpPost("{cartId:int}")]
    public async Task<ActionResult<OrderDto>> AddOrder(int cartId,
        OrderCreate orderCreate)
    {
        orderCreate.CartID = cartId;
        
        var createdOrder = _mapper.Map<Entities.Order>(orderCreate);
        _storeRepository.AddOrder(createdOrder);
        await _storeRepository.SaveChangesAsync();
        var createdOrderReturn = _mapper.Map<OrderDto>(createdOrder);
        
        return CreatedAtRoute("GetOrder",
            new
            {
                cartId = createdOrderReturn.CartId,
                id = createdOrderReturn.Id
            }, createdOrderReturn.Id);
    }
    
    [HttpPut("{cartId:int}/{orderId:int}")]
    public async Task<ActionResult> UpdateOrder(int cartId, int orderId,
        OrderUpdate orderUpdate)
    {

        orderUpdate.CartID = cartId;
        var orderEntity = await _storeRepository.GetOrderAsync(orderId);
        if (orderEntity == null)
        {
            return NotFound();
        }
        _mapper.Map(orderUpdate, orderEntity);
        await _storeRepository.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{orderId:int}")]
    public async Task<ActionResult> DeleteCart(int orderId)
    {
        var orderEntity = await _storeRepository.GetOrderAsync(orderId);
        if (orderEntity == null)
        {
            return NotFound();
        }
        _storeRepository.DeleteOrder(orderEntity);
        await _storeRepository.SaveChangesAsync();
        
        return NoContent();
    }
}