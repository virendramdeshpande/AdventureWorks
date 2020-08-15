using MediatR;
using NorthWind.Contracts.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.Query
{
    public class SampleQuery : IRequest<SampleResponse>
    {
    }
}
