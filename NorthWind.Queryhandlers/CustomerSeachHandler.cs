using AutoMapper;
using MediatR;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Contracts.Contracts.Response;
using NorthWind.Contracts.Customers.Query;
using NorthWind.Contracts.Customers.Search;
using NorthWind.Repositories.CustomerRepository;
using NorthWind.Repositories.InsurenceContractRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Queryhandlers
{
    public class CustomerSeachHandler : IRequestHandler<CustomerQuery, CustomerResponse>
    {
        ICustomerRepository _ICustomerRepository;
        IMapper _mapper;
        public CustomerSeachHandler(ICustomerRepository ICustomerRepository,
            IMapper _mapper)
        {
            this._ICustomerRepository = ICustomerRepository;
            this._mapper = _mapper;
        }

        //public async Task<ContractsResponse> Handle(ContractsQuery request, CancellationToken cancellationToken)
        //{
        //    await Task.Delay(1000);
        //    ContractsResponse contractsQueryResponse = new ContractsResponse();
         
        //    // Your logic here
        //    return contractsQueryResponse;
        //}


        public async Task<CustomerResponse> Handle(CustomerQuery request, System.Threading.CancellationToken cancellationToken)
        {
            CustomerResponse customerQueryResponse = new CustomerResponse();
            customerQueryResponse.ContractsQueryResults = new List<CustomerSearchQueryResult>();
            
            await foreach (var customer in _ICustomerRepository.GetAll())
            {
                
                customerQueryResponse.ContractsQueryResults.Add(_mapper.Map<CustomerSearchQueryResult>(customer));

            }
            // Your logic here
            return customerQueryResponse;
        }


    }
}

