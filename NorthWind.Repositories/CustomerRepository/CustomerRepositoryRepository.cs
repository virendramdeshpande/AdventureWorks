using Microsoft.EntityFrameworkCore;
using NorthWind.Repositories.AdventureWorks;
using NorthWind.Repositories.CustomerRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.InsurenceContractRepository
{
    public class CustomerRepositoryRepository : ICustomerRepository
    {
        private AdventureContext _AdventureContext;

        public async IAsyncEnumerable<Customer> GetAll()
        {
            _AdventureContext = new AdventureContext();
           
            await foreach (var item in _AdventureContext.Customer)
                yield return item;
        }
    }
}
