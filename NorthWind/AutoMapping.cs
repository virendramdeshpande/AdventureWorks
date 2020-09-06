using AutoMapper;
using NorthWind.Contracts.Customers.Query;
using NorthWind.Models;
using NorthWind.Repositories.AdventureWorks;

namespace NorthWind
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
           CreateMap<Customer, CustomerSearchQueryResult>();
            CreateMap<CustomerSearchQueryResult, CustomerSearchResultModel>(); // means you want to map from User to UserDTO
            
        }
        
    }
}
