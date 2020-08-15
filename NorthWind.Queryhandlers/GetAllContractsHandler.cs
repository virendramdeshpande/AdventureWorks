using AutoMapper;
using MediatR;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Contracts.Contracts.Response;

using NorthWind.Repositories.InsurenceContractRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Queryhandlers
{
    public class GetAllContractsHandler : IRequestHandler<ContractsQuery, ContractsResponse>
    {
        IInsurenceContractRepository _InsurenceContractRepository ;
        IMapper _mapper;
        public GetAllContractsHandler(IInsurenceContractRepository IInsurenceContractRepository,
            IMapper _mapper)
        {
            this._InsurenceContractRepository = IInsurenceContractRepository;
            this._mapper = _mapper;
        }

        //public async Task<ContractsResponse> Handle(ContractsQuery request, CancellationToken cancellationToken)
        //{
        //    await Task.Delay(1000);
        //    ContractsResponse contractsQueryResponse = new ContractsResponse();
         
        //    // Your logic here
        //    return contractsQueryResponse;
        //}


        public async Task<ContractsResponse> Handle(ContractsQuery request, System.Threading.CancellationToken cancellationToken)
        {
            ContractsResponse contractsQueryResponse = new ContractsResponse();
            await foreach (var contract in _InsurenceContractRepository.GetAllContracts())
            {
                contractsQueryResponse.ContractsQueryResults = new List<ContractsQueryResult>();

                var contractsQueryResult = _mapper.Map<ContractsQueryResult>(contract);



                contractsQueryResponse.ContractsQueryResults.Add(contractsQueryResult);

            }
            // Your logic here
            return contractsQueryResponse;
        }


    }
}

