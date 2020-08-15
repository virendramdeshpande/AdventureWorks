using Microsoft.EntityFrameworkCore;
using NorthWind.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.InsurenceContractRepository
{
    public class InsurenceContractRepository : IInsurenceContractRepository
    {
        private readonly DatabaseContext _context;


        public InsurenceContractRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<ContractsEntity> GetAllContracts()
        {
                   await foreach (var item in _context.Contracts)
                    yield return item;
         
            
           
        }
        public async Task Update(ContractsEntity contractsEntity)
        {
            var item = _context.Contracts.FirstOrDefault(o => o.Address == contractsEntity.Address && o.Country == contractsEntity.Country &&
                                 o.DateOfBirth == contractsEntity.DateOfBirth && o.Gender == contractsEntity.Gender && o.SaleDate == contractsEntity.SaleDate && o.Name == contractsEntity.Name);
            if (item != null)
            {
                item.CoveragePlan = GetCoveragePlan(contractsEntity.Country, contractsEntity.SaleDate);
                item.NetPrice = GetNetRate(contractsEntity.DateOfBirth, contractsEntity.Gender, item.CoveragePlan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(ContractsEntity contractsEntity)
        {
            var item = _context.Contracts.FirstOrDefault(o => o.Address == contractsEntity.Address && o.Country == contractsEntity.Country &&
                                 o.DateOfBirth == contractsEntity.DateOfBirth && o.Gender == contractsEntity.Gender && o.SaleDate == contractsEntity.SaleDate && o.Name == contractsEntity.Name);
            if (item != null)
            {
                _context.Contracts.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> Save(ContractsEntity contractsEntity)
        {
            var contract = new ContractsEntity
            {
                Address = contractsEntity.Address,
                Country = contractsEntity.Country,
                DateOfBirth = contractsEntity.DateOfBirth,
                Gender = contractsEntity.Gender,
                SaleDate = contractsEntity.SaleDate,
                Name = contractsEntity.Name,
            };
            contract.CoveragePlan = GetCoveragePlan(contractsEntity.Country, contractsEntity.SaleDate);
            contract.NetPrice = GetNetRate(contractsEntity.DateOfBirth, contractsEntity.Gender, contract.CoveragePlan);
            contract.Id = _context.Contracts.Count() + 1;
            await _context.Contracts.AddAsync(contract);
           return await _context.SaveChangesAsync();
        }

        private string GetCoveragePlan(string country, DateTime saleDate)
        {
            return _context.CoveragePlan.SingleOrDefault(o => o.EligibilityCountry == country
                     && o.EligibilityDateTo >= saleDate && o.EligibilityDateFrom <= saleDate)?.CoveragePlan
                     ?? _context.CoveragePlan.Single(o => o.EligibilityCountry == "*").CoveragePlan;
        }

        private decimal GetNetRate(DateTime dob, string gender, string coveragePlan)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dob.Year;
            decimal rate = 0.0m;
            if ((dob.Month == currentDate.Month && currentDate.Day < dob.Day) || currentDate.Month < dob.Month)
            {
                age--;
            }
            if (coveragePlan == "Gold" && gender == "M" && age <= 40) rate = 1000;
            if (coveragePlan == "Gold" && gender == "M" && age > 40) rate = 2000;
            if (coveragePlan == "Gold" && gender == "F" && age <= 40) rate = 1200;
            if (coveragePlan == "Gold" && gender == "F" && age > 40) rate = 2500;

            if (coveragePlan == "Silver" && gender == "M" && age <= 40) rate = 1500;
            if (coveragePlan == "Silver" && gender == "M" && age > 40) rate = 2600;
            if (coveragePlan == "Silver" && gender == "F" && age <= 40) rate = 1900;
            if (coveragePlan == "Silver" && gender == "F" && age > 40) rate = 2800;

            if (coveragePlan == "Platinum" && gender == "M" && age <= 40) rate = 1900;
            if (coveragePlan == "Platinum" && gender == "M" && age > 40) rate = 2900;
            if (coveragePlan == "Platinum" && gender == "F" && age <= 40) rate = 2100;
            if (coveragePlan == "Platinum" && gender == "F" && age > 40) rate = 3200;
            return rate;
        }


    }
}
