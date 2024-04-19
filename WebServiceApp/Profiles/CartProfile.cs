using AutoMapper;

namespace WebServiceApp.Profiles;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<Entities.Cart, Models.CartDto>();
        CreateMap<Entities.Cart, Models.CartCreate>();     
        CreateMap<Entities.Cart, Models.CartUpdate>(); 
        CreateMap<Models.CartUpdate,Entities.Cart >();
        CreateMap<Models.CartCreate, Entities.Cart>();

    }
}