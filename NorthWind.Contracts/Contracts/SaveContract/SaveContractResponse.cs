using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.SaveContract
{
    public class SaveContractResponse : ResponseBase
    {
        public SaveContractResponse() : base()
        {

        }
        public SaveContractResponse(Exception ex) : base(ex)
        {

        }
    }
}
