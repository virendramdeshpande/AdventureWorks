using AutoMapper;
using MediatR;
using NorthWind.Contracts.Contracts.SaveContract;
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
    class SaveContracthandler : IRequestHandler<SaveContract, SaveContractResponse>
    {
        IInsurenceContractRepository _InsurenceContractRepository;
        IMapper _mapper;

        public SaveContracthandler(IInsurenceContractRepository IInsurenceContractRepository,
           IMapper _mapper)
        {
            this._InsurenceContractRepository = IInsurenceContractRepository;
            this._mapper = _mapper;
        }

        public async Task<SaveContractResponse> Handle(SaveContract request, CancellationToken cancellationToken)
        {
            SaveContractResponse saveContractResponse;
            try
            {
                var contractsEntity = _mapper.Map<ContractsEntity>(request);

                int Count = await _InsurenceContractRepository.Save(contractsEntity);
                if (Count == 1)
                {

                    saveContractResponse = new SaveContractResponse();
                    return saveContractResponse;
                }
                else
                {

                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                saveContractResponse = new SaveContractResponse(ex);
                return saveContractResponse;
            }



                 
           
        }


    }
   
}
