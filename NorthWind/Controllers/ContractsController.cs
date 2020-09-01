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
using NorthWind.Contracts.Contracts.Response;
using NorthWind.Contracts.Contracts.SaveContract;
using NorthWind.Contracts.Contracts.UpdateContract;
using NorthWind.Models;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace NorthWind.Controllers
{
   
   
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

        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ContractsModel> contractsModelList = new List<ContractsModel>(); ;
            

            ContractsQuery obj = new ContractsQuery();

            ContractsResponse contractsResponse = await _mediator.Send(obj);

            if (contractsResponse.isSuccessful == true)
            {
                foreach (var conteactResult in contractsResponse.ContractsQueryResults)
                {
                    contractsModelList.Add(_mapper.Map<ContractsModel>(conteactResult));

                }
               var jsonResult = new JsonResult(contractsModelList);
                jsonResult.StatusCode = StatusCodes.Status200OK;
                return jsonResult; 
            }
            else
            {
                var jsonResult = new JsonResult("");
                jsonResult.StatusCode = StatusCodes.Status500InternalServerError;
                return jsonResult;
                //var error = new JsonResult(contractsResponse.exception);
                //error.StatusCode = StatusCodes.Status500InternalServerError;
                //return error;
            }



          
        }


        [Microsoft.AspNetCore.Mvc.HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]  int Id)
        {
            DeleteContract deleteCommand = new DeleteContract();

            DeleteContractResponse deleteContractResponse = await _mediator.Send(deleteCommand);

            if (deleteContractResponse.isSuccessful == true)
            {
                return Ok(Id);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("The Contracts doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
        };
                    throw new HttpResponseException(response);
            }
            
        }
        
        
        [Microsoft.AspNetCore.Mvc.HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id)
        {
            UpdateContract updateCommand = new UpdateContract();

            UpdateContractResponse updateContractResponse = await _mediator.Send(updateCommand);

            if (updateContractResponse.isSuccessful == true)
            {
                return Ok(updateContractResponse.Data.AffectedRecords);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("The Contracts doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
            };
                throw new HttpResponseException(response);
            }
            
            
        }

        [HttpPost("/Save")]
        public async Task<IActionResult> Save(ContractsModel contractsModel)
        {
           
          
            var request=_mapper.Map<SaveContract>(contractsModel);

            SaveContractResponse saveContractResponse = await _mediator.Send(request);
         
            if(saveContractResponse.isSuccessful==true)
            {
               return Ok(saveContractResponse.Data.AffectedRecords);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("The Contracts doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(response);
            }
           
        }

    }
}
