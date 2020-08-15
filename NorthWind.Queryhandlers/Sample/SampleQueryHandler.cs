using MediatR;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Contracts.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Queryhandlers.Sample
{
    public class SampleQueryhandler : IRequestHandler<SampleQuery, SampleResponse>
    {
        public async Task<SampleResponse> Handle(SampleQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);

            return new SampleResponse();
        }
       
    }
}
