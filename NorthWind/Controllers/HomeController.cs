using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Models;


namespace NorthWind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            this._mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            SampleQuery allCustomersQuery = new SampleQuery();
            var CustomersQueryTask = this._mediator.Send(allCustomersQuery);
            var response = await CustomersQueryTask;

            //ContractsQuery obj = new ContractsQuery();

            //var response1 = await _mediator.Send(obj);


            return View(response);
            //return Ok(response);
        }


        public async Task<IActionResult> Contracts()
        {
            SampleQuery obj = new SampleQuery();

            var response1 = await  _mediator.Send(obj);
        
            return View(response1);
            //return Ok(response);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
