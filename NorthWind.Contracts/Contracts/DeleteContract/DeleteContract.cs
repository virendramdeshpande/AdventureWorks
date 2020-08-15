using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.DeleteContract
{
    public class DeleteContract: IRequest<DeleteContractResponse>
    {
        public int Id { get; set; }
        
    }
}
