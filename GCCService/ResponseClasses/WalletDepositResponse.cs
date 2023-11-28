using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.ResponseClasses
{
    public class WalletDepositResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Successful { get; set; }

        public List<Table> dsTransactionList { get; set; }

        public string toString()
        {
            string resp = "";

            if (dsTransactionList.Count > 0)
            {
                resp = "WalletDepositResponse[ ResponseCode=" + ResponseCode + ", ResponseMessage=" + ResponseMessage + ", Successful=" + Successful
                    + ", Count=" + dsTransactionList.Count + ", ";

                for (int ii = 0; ii < dsTransactionList.Count; ii++)
                {
                    resp += dsTransactionList[ii].toStringVal();
                }
                return resp;
            }
            else
            {
                return "WalletDepositResponse[ ResponseCode=" + ResponseCode + ", ResponseMessage=" + ResponseMessage + ", Successful=" + Successful
                    + ", Count=" + dsTransactionList.Count + "]";
            }
        }
    }

    public class Table
    {
        public string TransactionNo { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ValueDate { get; set; }
        public string PayinCountryName { get; set; }
        public string PayinCountryCode { get; set; }
        public string PayinCurrencyCode { get; set; }
        public float PayinAmount { get; set; }
        public float ExchangeRate { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderMiddleName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderFourthName { get; set; }
        public string SenderFullName { get; set; }
        public string SenderNationality { get; set; }
        public string SenderContactNo { get; set; }
        public string SenderIDType { get; set; }
        public string SenderIDPlaceOfIssue { get; set; }
        public string SenderIDNumber { get; set; }
        public DateTime SenderIDExpiryDate { get; set; }
        public string SenderOccupation { get; set; }
        public string SenderIncomeSource { get; set; }
        public string Purpose { get; set; }
        public string PayoutCountryName { get; set; }
        public string PayoutCountryCode { get; set; }
        public string PayoutCityName { get; set; }
        public string PayoutLocationName { get; set; }
        public string PayoutLocationCode { get; set; }
        public string PayoutLocationCode2 { get; set; }
        public string PaymentMode { get; set; }
        public string PayoutCurrencyCode { get; set; }
        public float PayoutAmount { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverMiddleName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverFourthName { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverContactNo { get; set; } // wallet acc number
        public string ReceiverNationality { get; set; }
        public string Status { get; set; }
        //public string Id { get; set; }
        //public string RowOrder { get; set; }

        public string toStringVal()
        {
            return "[TrxnNo=" + TransactionNo + ", ValueDate=" + ValueDate.ToShortDateString() + ", PayoutAmount=" + PayoutAmount + ", Status=" + Status
                + ", ReceiverName=" + ReceiverFullName + ", SenderName=" + SenderFullName + ", PayinCountry=" + PayinCountryName
                + ", PayinCurrency=" + PayinCurrencyCode + ", PayinAmount=" + PayinAmount + ", ExchangeRate=" + ExchangeRate + ", SenderNationality=" + SenderNationality
                + ", SenderContactNo=" + SenderContactNo + ", SenderOccupation=" + SenderOccupation + ", SenderIncomeSource=" + SenderIncomeSource + ", Purpose=" + Purpose
                + ", PaymentMode=" + PaymentMode + ", ReceiverContactNo=" + ReceiverContactNo + ", ReceiverNationality=" + ReceiverNationality + ", PayoutLocationName=" + PayoutLocationName + "]";

        }

    }

}