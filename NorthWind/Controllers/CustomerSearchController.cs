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
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Contracts.Contracts.Response;
using NorthWind.Contracts.Customers.Query;
using NorthWind.Contracts.Customers.Search;
using NorthWind.Models;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace NorthWind.Controllers
{
   
   
    public class CustomerSearchController : ControllerBase
    {
       
        private IMapper _mapper;
        private IMediator _mediator;
        public CustomerSearchController( IMediator mediator, IMapper _mapper)
        {          
           this._mediator = mediator;
            this._mapper = _mapper;
        }

        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CustomerSearchResultModel> contractsModelList = new List<CustomerSearchResultModel>(); ;


            CustomerQuery obj = new CustomerQuery();

            CustomerResponse contractsResponse = await _mediator.Send(obj);

            if (contractsResponse.isSuccessful == true)
            {
                foreach (var conteactResult in contractsResponse.ContractsQueryResults)
                {
                    contractsModelList.Add(_mapper.Map<CustomerSearchResultModel>(conteactResult));

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

            }



          
        }
     
    }
}
