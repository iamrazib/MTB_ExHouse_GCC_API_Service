using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.RequestClasses
{
    public class WalletDepositRequest
    {
        public string AccountNo { get; set; }

        public string toString()
        {
            return "WalletDepositRequest[ AccountNo=" + AccountNo + "]";
        }
    }
}