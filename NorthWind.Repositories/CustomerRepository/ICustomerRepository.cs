using NorthWind.Repositories.AdventureWorks;
using System.Collections.Generic;


namespace NorthWind.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        IAsyncEnumerable<Customer> GetAll();
        
    }
}
