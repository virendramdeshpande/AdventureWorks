using NorthWind.Contracts.Contracts_base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts.SaveContract
{
    public class SaveContractResponse : ResponseBase
    {
        public SaveContractResult Data { get; set; }
        public SaveContractResponse() : base()
        {

        }
        public SaveContractResponse(Exception ex) : base(ex)
        {

        }
    }
    public class SaveContractResult
    {
        public int AffectedRecords { get; set; }
    }
}
