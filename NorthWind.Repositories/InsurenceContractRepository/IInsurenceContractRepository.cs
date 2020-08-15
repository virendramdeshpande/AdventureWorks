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
        Task Save(ContractsEntity contractsEntity);
        Task Update(ContractsEntity contractsEntity);
        Task Delete(ContractsEntity contractsEntity);
    }
}
