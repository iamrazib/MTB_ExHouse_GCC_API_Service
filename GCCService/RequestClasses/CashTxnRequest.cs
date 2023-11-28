using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCCService
{
    public class CashTxnRequest
    {
        public string TransactionNo { get; set; }

        public string toString()
        {
            return "CashTxnRequest[ TransactionNo=" + TransactionNo + "]";
        }
    }
}
