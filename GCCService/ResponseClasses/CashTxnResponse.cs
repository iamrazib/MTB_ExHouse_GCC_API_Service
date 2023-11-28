using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.ResponseClasses
{
    public class CashTxnResponse
    {
        public string AmountToPay { get; set; }
        public string AmountToPayInWords { get; set; }
        public string PurposeCode { get; set; }
        public string PurposeName { get; set; }
        public string ReceiveCountryCode { get; set; }
        public string ReceiveCountryName { get; set; }
        public string ReceiveCurrencyCode { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverContactNo { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverFourthName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverMiddleName { get; set; }
        public string ReceiverNationality { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string SendCountryCode { get; set; }
        public string SendCountryName { get; set; }
        public string SenderAddress { get; set; }
        public string SenderCity { get; set; }
        public string SenderContactNo { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderFourthName { get; set; }
        public string SenderIDExpiryDate { get; set; }
        public string SenderIDNumber { get; set; }
        public string SenderIDPlaceOfIssue { get; set; }
        public string SenderIDTypeCode { get; set; }
        public string SenderIDTypeName { get; set; }
        public string SenderIncomeSourceCode { get; set; }
        public string SenderIncomeSourceName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderMiddleName { get; set; }
        public string SenderNationality { get; set; }
        public string SenderOccupationCode { get; set; }
        public string SenderOccupationName { get; set; }
        public string Status { get; set; }
        public string Successful { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionNo { get; set; }

        public string toString()
        {
            return "CashTxnResponse[ TransactionNo=" + TransactionNo + ", ResponseCode=" + ResponseCode + ", ResponseMessage=" + ResponseMessage + ", Status=" + Status
                + ", Successful=" + Successful + ", Amount=" + AmountToPay + ", ReceiverName=" + (ReceiverFirstName + " " + ReceiverMiddleName + " " + ReceiverLastName + " " + ReceiverFourthName).Trim()
                + ", ReceiverAddress=" + ReceiverAddress + ", ReceiverContactNo=" + ReceiverContactNo + ", Purpose=" + PurposeName
                + ", SenderName=" + (SenderFirstName + " " + SenderMiddleName + " " + SenderLastName + " " + SenderFourthName).Trim() + ", SendCountry=" + SendCountryName
                + ", SenderOccupation=" + SenderOccupationName + ", TransactionDate=" + TransactionDate + "]";
        }


    }
}