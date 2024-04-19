using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServiceApp.Models;
using WebServiceApp.Services;


namespace WebServiceApp.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;
    
    public ProductController(IStoreRepository storeRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var productEntities = await _storeRepository.GetProductsAsync();
        
        return Ok(_mapper.Map<IEnumerable<ProductDto>>(productEntities));
    }
    
    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<IActionResult> GetProduct(int id)
    {        
        if(!await _storeRepository.ProductExistsAsync(id)) 
        { return NotFound(); }
        var product = await _storeRepository.GetProductAsync(id);
        
        return Ok(_mapper.Map<ProductDto>(product));
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(
        ProductCreate productCreate)
    {
        var createdProduct = _mapper.Map<Entities.Product>(productCreate);
        _storeRepository.AddProduct(createdProduct);
        await _storeRepository.SaveChangesAsync();
        var createdProductReturn = _mapper.Map<ProductDto>(createdProduct);

        return CreatedAtRoute("GetProduct",
            new
            {
                id = createdProductReturn.Id
            }, createdProductReturn);
    }
    
    [HttpPut("{productId:int}")]
    public async Task<ActionResult> UpdateProduct(int productId,
        ProductUpdate product)
    {
        var productEntity = await _storeRepository.GetProductAsync(productId);
        if (productEntity == null)
        {
            return NotFound();
        }
        _mapper.Map(product, productEntity);
        await _storeRepository.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult> DeleteProduct(int productId)
    {
        var productEntity = await _storeRepository.GetProductAsync(productId);
        if (productEntity == null)
        {
            return NotFound();
        }
        _storeRepository.DeleteProduct(productEntity);
        await _storeRepository.SaveChangesAsync();
        
        return NoContent();
    }
}