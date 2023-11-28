using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.ResponseClasses
{
    public class ProcessTransResponse
    {
        public float AmountToPay { get; set; }
        public string AmountToPayInWords { get; set; }
        public string ReceiveCountryName { get; set; }
        public string ReceiveCurrencyCode { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string SendCountryCode { get; set; }
        public string Status { get; set; }
        public string Successful { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionNo { get; set; }


        public string toString()
        {
            return "ProcessTransResponse[ TransactionNo=" + TransactionNo + ", ResponseCode=" + ResponseCode + ", ResponseMessage=" + ResponseMessage
                + ", Status=" + Status + ", Successful=" + Successful + ", AmountToPay=" + AmountToPay + ", TransactionDate=" + TransactionDate
                + ", RecvCountry=" + ReceiveCountryName + ", RecvCurr=" + ReceiveCurrencyCode + "]";
        }
    }
}