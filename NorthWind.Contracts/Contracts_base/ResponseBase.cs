using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Contracts.Contracts_base
{
    public class ResponseBase
    {
        public bool isSuccessful { get; set; }
        Exception exception { get; set; }
        public ResponseBase()
        {
            isSuccessful = true;
        }
        public ResponseBase(Exception ex)
        {
            isSuccessful = false;
            exception = ex;
        }

    }
}
