using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.DeleteContract
{

    public class DeleteContractResponse : ResponseBase
    {
        public DeleteContractResponse() : base()
        {

        }
        public DeleteContractResponse(Exception ex) : base(ex)
        {

        }
    }
}
