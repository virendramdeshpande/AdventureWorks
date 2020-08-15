using MediatR;
using NorthWind.Contracts.Contracts.Response;


namespace NorthWind.Contracts.Contracts.Query
{
    public class ContractsQuery : IRequest<ContractsResponse>
    {
        public int id { set; get; }
    }

}
