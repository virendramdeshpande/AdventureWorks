using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Test
{
    public class SampleQueryHandler : IRequestHandler<SampleQuery, SampleResponse>
    {
        public async Task<SampleResponse> Handle(SampleQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);

            return new SampleResponse();
        }
       
    }
}
