using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.ResponseClasses
{
    public class UpdateBankDepositResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Status { get; set; }
        public string Successful { get; set; }
        public string TransactionNo { get; set; }

        public string toString()
        {
            return "UpdateBankDepositResponse[ TransactionNo=" + TransactionNo + ", ResponseCode=" + ResponseCode + ", ResponseMessage=" + ResponseMessage
                + ", Status=" + Status + ", Successful=" + Successful + "]";
        }

    }
}