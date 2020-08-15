using AutoMapper;
using MediatR;
using NorthWind.Contracts.Contracts.DeleteContract;
using NorthWind.Contracts.Contracts.UpdateContract;
using NorthWind.Repositories.Entities;
using NorthWind.Repositories.InsurenceContractRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Commandhandler
{
    class DeleteContractHandler : IRequestHandler<DeleteContract, DeleteContractResponse>
    {
        IInsurenceContractRepository _InsurenceContractRepository;
        IMapper _mapper;

        public DeleteContractHandler(IInsurenceContractRepository IInsurenceContractRepository,
           IMapper _mapper)
        {
            this._InsurenceContractRepository = IInsurenceContractRepository;
            this._mapper = _mapper;
        }

        public async Task<DeleteContractResponse> Handle(DeleteContract request, CancellationToken cancellationToken)
        {
            DeleteContractResponse deleteContractResponse;
            try
            {
                var contractsEntity = _mapper.Map<ContractsEntity>(request);

                int Count = await _InsurenceContractRepository.Save(contractsEntity);

                deleteContractResponse = new DeleteContractResponse();
                return deleteContractResponse;
            }
            catch (Exception ex)
            {
                deleteContractResponse = new DeleteContractResponse(ex);
                return deleteContractResponse;
            }


        }
    }
}
