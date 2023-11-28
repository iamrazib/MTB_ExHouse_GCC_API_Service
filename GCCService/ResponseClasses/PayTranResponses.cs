using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.ResponseClasses
{
    public class PayTranResponses
    {
        public bool Successful { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string TransactionNo { get; set; }
        public string Status { get; set; }
        public string TransactionDate { get; set; }
        public string ReceiveCountryName { get; set; }
        public string ReceiveCurrencyCode { get; set; }
        public string AmountToPay { get; set; }

        public string toString()
        {
            return "PayTranResponses[ TransactionNo=" + TransactionNo + ", Success=" + Successful + ", RespCode=" + ResponseCode
                + ", RespMessage=" + ResponseMessage + ", Status=" + Status + ", TransactionDate=" + TransactionDate + ", ReceiveCountry=" + ReceiveCountryName
                + ", ReceiveCurrency=" + ReceiveCurrencyCode + ", AmountToPay=" + AmountToPay + " ]";
        }

    }
}