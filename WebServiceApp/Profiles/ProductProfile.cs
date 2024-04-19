namespace WebServiceApp.Profiles;
using AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Entities.Product, Models.ProductDto>();
        CreateMap<Entities.Product, Models.ProductUpdate>();      
        CreateMap<Entities.Product, Models.ProductCreate>(); 
        CreateMap<Models.ProductCreate,Entities.Product >();
        CreateMap<Models.ProductUpdate, Entities.Product>();
    }
    
}