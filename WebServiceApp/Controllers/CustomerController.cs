using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServiceApp.Models;
using WebServiceApp.Services;
using Microsoft.AspNetCore.JsonPatch;


namespace WebServiceApp.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    
    public CustomerController(IStoreRepository storeRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customerEntities = await _storeRepository.GetCustomersAsync();

        return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customerEntities));
    }
    
    [HttpGet("{id:int}", Name = "GetCustomer")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        if (!await _storeRepository.CustomerExistsAsync(id))
        {
            return NotFound();
        }
        var customer = await _storeRepository.GetCustomerAsync(id);
        
        return Ok(_mapper.Map<CustomerDto>(customer));
    }
    
    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(
        CustomerCreate customerCreate)
    {
        var createdCustomer = _mapper.Map<Entities.Customer>(customerCreate);
        _storeRepository.AddCustomer(createdCustomer);
        await _storeRepository.SaveChangesAsync();
        var createdCustomerReturn = _mapper.Map<CustomerDto>(createdCustomer);
        
        return CreatedAtRoute("GetCustomer",
            new
            {
                id = createdCustomerReturn.Id
            }, createdCustomerReturn);
    }
    
    [HttpPut("{customerId:int}")]
    public async Task<ActionResult> UpdateCustomer(int customerId,
        CustomerUpdate customerUpdate)
    {
        var customerEntity = await _storeRepository.GetCustomerAsync(customerId);
        if (customerEntity == null)
        {
            return NotFound();
        }
        _mapper.Map(customerUpdate, customerEntity);
        await _storeRepository.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{customerId:int}")]
    public async Task<ActionResult> DeleteCustomer(int customerId)
    {
        var customerEntity = await _storeRepository.GetCustomerAsync(customerId);
        if (customerEntity == null)
        {
            return NotFound();
        }
        _storeRepository.DeleteCustomer(customerEntity);
        await _storeRepository.SaveChangesAsync();
        
        return NoContent();
    }
}