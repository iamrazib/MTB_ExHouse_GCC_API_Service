using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.RequestClasses
{
    public class PayTranRequest
    {
        public string TransactionNo { get; set; }
        public string ReceiverIDType { get; set; }
        public string ReceiverIDPlaceOfIssue { get; set; }
        public string ReceiverIDNumber { get; set; }
        public string ReceiverIDExpiryDate { get; set; }


        public string toString()
        {
            return "PayTranRequest[ TransactionNo=" + TransactionNo + ", ReceiverIDType=" + ReceiverIDType + ", IDPlaceOfIssue=" + ReceiverIDPlaceOfIssue
                + ", IDNumber=" + ReceiverIDNumber + ", IDExpiryDate=" + ReceiverIDExpiryDate + "]";
        }
    }
}