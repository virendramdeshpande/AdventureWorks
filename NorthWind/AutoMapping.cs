using AutoMapper;
using NorthWind.Contracts.Contracts.Response;
using NorthWind.Contracts.Contracts.UpdateContract;
using NorthWind.Models;
using NorthWind.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ContractsEntity, ContractsQueryResult>(); // means you want to map from User to UserDTO
            CreateMap<ContractsQueryResult, ContractsModel>();

            CreateMap<ContractsEntity, UpdateContract>(); // means you want to map from User to UserDTO
         
        }
    }
}
