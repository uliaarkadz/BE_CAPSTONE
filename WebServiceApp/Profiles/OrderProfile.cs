using AutoMapper;

namespace WebServiceApp.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Entities.Order, Models.OrderDto>();
        CreateMap<Entities.Order, Models.OrderCreate>();     
        CreateMap<Entities.Order, Models.OrderUpdate>(); 
        CreateMap<Models.OrderUpdate,Entities.Order >();
        CreateMap<Models.OrderCreate, Entities.Order>();

    }
}