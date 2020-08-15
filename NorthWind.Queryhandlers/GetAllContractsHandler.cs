using MediatR;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Contracts.Contracts.Response;

using NorthWind.Repositories.InsurenceContractRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Queryhandlers
{
    public class GetAllContractsHandler : IRequestHandler<ContractsQuery, ContractsResponse>
    {
        IInsurenceContractRepository _InsurenceContractRepository;
        public GetAllContractsHandler(IInsurenceContractRepository IInsurenceContractRepository)
        {
            this._InsurenceContractRepository = IInsurenceContractRepository;
        }

        public async Task<ContractsResponse> Handle(ContractsQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
            ContractsResponse contractsQueryResponse = new ContractsResponse();
         
            // Your logic here
            return contractsQueryResponse;
        }


        /*public async Task<ContractsResponse> Handle(AllCustomersQuery request, System.Threading.CancellationToken cancellationToken)
        {
            ContractsResponse contractsQueryResponse = new ContractsResponse();
            await foreach (var contract in _InsurenceContractRepository.GetAllContracts())
            {
                contractsQueryResponse.ContractsQueryResults = new List<ContractsQueryResult>();

                contractsQueryResponse.ContractsQueryResults.Add(new ContractsQueryResult());

            }
            // Your logic here
            return contractsQueryResponse;
        }*/


    }
}

