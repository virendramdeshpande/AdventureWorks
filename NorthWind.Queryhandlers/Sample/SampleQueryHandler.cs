using MediatR;
using NorthWind.Contracts.Contracts.Query;
using NorthWind.Contracts.Contracts.Response;
using NorthWind.Repositories.InsurenceContractRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.Queryhandlers.Sample
{
    public class SampleQueryhandler : IRequestHandler<SampleQuery, SampleResponse>
    {
        public IInsurenceContractRepository _insurenceContractRepository;
        public SampleQueryhandler(IInsurenceContractRepository insurenceContractRepository)
        {
            this._insurenceContractRepository = insurenceContractRepository;
        }
        public async Task<SampleResponse> Handle(SampleQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);

            return new SampleResponse();
        }
       
    }
}
