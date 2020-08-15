using AutoMapper;
using MediatR;
using NorthWind.Contracts.Contracts.UpdateContract;
using NorthWind.Repositories.Entities;
using NorthWind.Repositories.InsurenceContractRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Commandhandler
{
    public class UpdateContractHandler : IRequestHandler<UpdateContract, UpdateContractResponse>
    {
        IInsurenceContractRepository _InsurenceContractRepository;
        IMapper _mapper;

        public UpdateContractHandler(IInsurenceContractRepository IInsurenceContractRepository,
           IMapper _mapper)
        {
            this._InsurenceContractRepository = IInsurenceContractRepository;
            this._mapper = _mapper;
        }

        public async Task<UpdateContractResponse> Handle(UpdateContract request, CancellationToken cancellationToken)
        {
            UpdateContractResponse updateContractResponse;
            try
            {
                var contractsEntity = _mapper.Map<ContractsEntity>(request);

                int Count = await _InsurenceContractRepository.Save(contractsEntity);

                updateContractResponse =  new UpdateContractResponse();
                return updateContractResponse;
            }
            catch(Exception ex)
            {
                updateContractResponse= new UpdateContractResponse(ex);
                return updateContractResponse;
            }
          
           
        }
    }
}
