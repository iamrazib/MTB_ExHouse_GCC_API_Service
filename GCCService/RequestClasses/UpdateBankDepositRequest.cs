using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.RequestClasses
{
    public class UpdateBankDepositRequest
    {
        public string TransactionNo { get; set; }

        public string toString()
        {
            return "UpdateBankDepositRequest[ TransactionNo=" + TransactionNo + "]";
        }
    }
}