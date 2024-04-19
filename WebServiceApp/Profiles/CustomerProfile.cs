using AutoMapper;

namespace WebServiceApp.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Entities.Customer, Models.CustomerDto>();
        CreateMap<Entities.Customer, Models.CustomerUpdate>();     
        CreateMap<Entities.Customer, Models.CustomerCreate>(); 
        CreateMap<Models.CustomerCreate,Entities.Customer >();
        CreateMap<Models.CustomerUpdate, Entities.Customer>();

    }
}