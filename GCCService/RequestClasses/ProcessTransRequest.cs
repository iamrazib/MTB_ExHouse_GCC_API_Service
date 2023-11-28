using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.RequestClasses
{
    public class ProcessTransRequest
    {
        public string TransactionNo { get; set; }

        public string toString()
        {
            return "ProcessTransRequest[ TransactionNo=" + TransactionNo + "]";
        }
    }
}