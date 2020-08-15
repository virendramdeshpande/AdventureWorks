using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthWind.Contracts.Contracts.DeleteContract;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Models;

namespace NorthWind.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private IMapper _mapper;
        private IMediator _mediator;
        public ContractsController(ILogger<HomeController> logger, IMediator mediator, IMapper _mapper)
        {
            _logger = logger;
            this._mediator = mediator;
            this._mapper = _mapper;
        }

        [System.Web.Http.HttpGet]
        public async Task<List<ContractsModel>> GetAll()
        {
            List<ContractsModel> contractsModelList = new List<ContractsModel>(); ;
            

            ContractsQuery obj = new ContractsQuery();

            var response1 = await _mediator.Send(obj);

            foreach (var conteactResult in response1.ContractsQueryResults)
            {
                contractsModelList.Add(_mapper.Map<ContractsModel>(conteactResult));

            }

            return contractsModelList;
        }


        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ContractsModel> Delete(ContractsModel model)
        {
            DeleteContract deleteCommand = new DeleteContract();

            var deleteCommandResult = await _mediator.Send(deleteCommand);

            if (deleteCommandResult == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("The Contracts doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                    throw new HttpResponseException(response);
            }
            return model;
        }
    }
}
