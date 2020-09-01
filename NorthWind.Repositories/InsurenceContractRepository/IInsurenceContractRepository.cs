using NorthWind.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.InsurenceContractRepository
{
    public interface IInsurenceContractRepository
    {
        IAsyncEnumerable<ContractsEntity> GetAllContracts();
        Task<int> SaveContract(ContractsEntity contractsEntity);
        Task<int> UpdateContract(ContractsEntity contractsEntity);
        Task<int> DeleteContract(ContractsEntity contractsEntity);
    }
}
