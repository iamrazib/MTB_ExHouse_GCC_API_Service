using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.RequestClasses
{
    public class BankDepositRequest
    {
        public string AccountNo { get; set; }

        public string toString()
        {
            return "BankDepositRequest[ AccountNo=" + AccountNo + "]";
        }
    }
}