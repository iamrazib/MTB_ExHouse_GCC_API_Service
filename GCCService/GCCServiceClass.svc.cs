using GCCService.GCCServiceReference;
using GCCService.Global;
using GCCService.Global.Definitions.securityCode;
using GCCService.Global.Definitions.ServiceID;
using GCCService.Manager;
using GCCService.RequestClasses;
using GCCService.ResponseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

/*
 * Live Service
 * Author: Sk. Razibul Islam
 * 26-Jan-2022: Wallet API added
 * 30-Jan-2022: Bank Deposit module updated for wallet txn
 */

namespace GCCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GCCServiceClass : IGCCService
    {
        ReceiveAPIClient gccClient = new ReceiveAPIClient();

        // Initialization for Log purpose
        LogManager LogObj = new LogManager();
        string RequestCode = null;
        int LogID = 0;
        int isAuthenticated = 0;
        // end 


        public CashTxnResponse DisplayTransaction(string securityCode, string TransactionNo)
        {
            string UniqueID = Global.Definitions.GCCCredentials.credValue.UniqueID;
            string Password = Global.Definitions.GCCCredentials.credValue.Password;
            string SecurityKey = Global.Definitions.GCCCredentials.credValue.SecurityKey;
            CashTxnResponse cashTxn = new CashTxnResponse();
            CashTxnRequest cshReq = new CashTxnRequest();

            LogID = 0;
            isAuthenticated = 0;
            string exHouseName = Global.Definitions.ExchangeHouse.ExHName.gcc;

            try
            {
                RequestCode = "SecurityCode:" + securityCode;
                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransaction, isAuthenticated, RequestCode, "", "");

                if (string.Equals(securityCode, secValue.AccessCode))
                {
                    isAuthenticated = 1;
                    RequestCode = "SecurityCode:Passed";
                    LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransaction, isAuthenticated, RequestCode, "", "");
                                      
                    try
                    {
                        DisplayTransactionRequest dtReq = new DisplayTransactionRequest();
                        dtReq.Password = Password;
                        dtReq.SecurityKey = SecurityKey;
                        dtReq.TransactionNo = TransactionNo;
                        dtReq.UniqueID = UniqueID;

                        cshReq.TransactionNo = TransactionNo;

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                        DisplayTransactionResponse dtResp = gccClient.DisplayTransaction(dtReq);

                        if (dtResp.ResponseCode.Equals("001"))
                        {
                            cashTxn.AmountToPay = dtResp.AmountToPay.ToString();
                            cashTxn.AmountToPayInWords = dtResp.AmountToPayInWords;
                            cashTxn.PurposeCode = dtResp.PurposeCode;
                            cashTxn.PurposeName = dtResp.PurposeName;
                            cashTxn.ReceiveCountryCode = dtResp.ReceiveCountryCode;
                            cashTxn.ReceiveCountryName = dtResp.ReceiveCountryName;
                            cashTxn.ReceiveCurrencyCode = dtResp.ReceiveCurrencyCode;
                            cashTxn.ReceiverAddress = dtResp.ReceiverAddress;
                            cashTxn.ReceiverCity = dtResp.ReceiverCity;
                            cashTxn.ReceiverContactNo = dtResp.ReceiverContactNo;
                            cashTxn.ReceiverFirstName = dtResp.ReceiverFirstName;
                            cashTxn.ReceiverFourthName = dtResp.ReceiverFourthName;
                            cashTxn.ReceiverLastName = dtResp.ReceiverLastName;
                            cashTxn.ReceiverMiddleName = dtResp.ReceiverMiddleName;
                            cashTxn.ReceiverNationality = dtResp.ReceiverNationality;
                            cashTxn.ResponseCode = dtResp.ResponseCode;
                            cashTxn.ResponseMessage = dtResp.ResponseMessage;
                            cashTxn.SendCountryCode = dtResp.SendCountryCode;
                            cashTxn.SendCountryName = dtResp.SendCountryName;
                            cashTxn.SenderAddress = dtResp.SenderAddress;
                            cashTxn.SenderCity = dtResp.SenderCity;
                            cashTxn.SenderContactNo = dtResp.SenderContactNo;
                            cashTxn.SenderFirstName = dtResp.SenderFirstName;
                            cashTxn.SenderFourthName = dtResp.SenderFourthName;
                            cashTxn.SenderIDExpiryDate = dtResp.SenderIDExpiryDate;
                            cashTxn.SenderIDNumber = dtResp.SenderIDNumber;
                            cashTxn.SenderIDPlaceOfIssue = dtResp.SenderIDPlaceOfIssue;
                            cashTxn.SenderIDTypeCode = dtResp.SenderIDTypeCode;
                            cashTxn.SenderIDTypeName = dtResp.SenderIDTypeName;
                            cashTxn.SenderIncomeSourceCode = dtResp.SenderIncomeSourceCode;
                            cashTxn.SenderIncomeSourceName = dtResp.SenderIncomeSourceName;
                            cashTxn.SenderLastName = dtResp.SenderLastName;
                            cashTxn.SenderMiddleName = dtResp.SenderMiddleName;
                            cashTxn.SenderNationality = dtResp.SenderNationality;
                            cashTxn.SenderOccupationCode = dtResp.SenderOccupationCode;
                            cashTxn.SenderOccupationName = dtResp.SenderOccupationName;
                            cashTxn.Status = dtResp.Status;
                            cashTxn.Successful = dtResp.Successful.ToString();
                            cashTxn.TransactionDate = dtResp.TransactionDate;
                            cashTxn.TransactionNo = dtResp.TransactionNo;
                        }
                        else
                        {
                            cashTxn.ResponseCode = dtResp.ResponseCode;
                            cashTxn.ResponseMessage = dtResp.ResponseMessage;
                            cashTxn.Status = dtResp.Status;
                            cashTxn.Successful = dtResp.Successful.ToString();
                        }

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransaction, isAuthenticated, RequestCode, cshReq.toString(), cashTxn.toString());
                    
                        
                    }// END try
                    catch (Exception Ex)
                    {
                        cashTxn.ResponseCode = "000";
                        cashTxn.ResponseCode = Ex.Message;
                        cashTxn.ResponseMessage = Ex.StackTrace;

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransaction, isAuthenticated, RequestCode, cashTxn.ResponseCode, cashTxn.ResponseMessage);
                    }

                }// END (string.Equals(securityCode, secValue.AccessCode))

            }
            catch (Exception exc)
            {
                cashTxn.ResponseCode = "000";

                string errorCode = "000 : Technical Error";
                string errorMsg = exc.Message;
                string errorStackTrace = exc.StackTrace;
                LogObj.InsertIntoExHouseAPIErrorLog("ReceivePayment", errorCode, errorMsg, errorStackTrace);
            }

            return cashTxn;
        }


        public PayTranResponses PayTransaction(string securityCode, string TransactionNo, string ReceiverIDType, string ReceiverIDNumber)
        {
            string UniqueID = Global.Definitions.GCCCredentials.credValue.UniqueID;
            string Password = Global.Definitions.GCCCredentials.credValue.Password;
            string SecurityKey = Global.Definitions.GCCCredentials.credValue.SecurityKey;
            PayTranResponses payTxnResp = new PayTranResponses();
            PayTranRequest payTxnReq = new PayTranRequest();

            LogID = 0;
            isAuthenticated = 0;
            string exHouseName = Global.Definitions.ExchangeHouse.ExHName.gcc;

            try
            {
                RequestCode = "SecurityCode:" + securityCode;
                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.PayTransaction, isAuthenticated, RequestCode, "", "");

                if (string.Equals(securityCode, secValue.AccessCode))
                {
                    isAuthenticated = 1;
                    RequestCode = "SecurityCode:Passed";
                    LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.PayTransaction, isAuthenticated, RequestCode, "", "");

                    try
                    {
                        PayTransactionRequest dtPayTranReq = new PayTransactionRequest();
                        dtPayTranReq.Password = Password;
                        dtPayTranReq.SecurityKey = SecurityKey;
                        dtPayTranReq.TransactionNo = TransactionNo;
                        dtPayTranReq.UniqueID = UniqueID;
                        dtPayTranReq.ReceiverIDType = ReceiverIDType;
                        dtPayTranReq.ReceiverIDPlaceOfIssue = "BD";
                        dtPayTranReq.ReceiverIDNumber = ReceiverIDNumber;
                        dtPayTranReq.ReceiverIDExpiryDate = DateTime.Now.AddYears(1).ToString("dd-MMM-yyyy");

                        payTxnReq.TransactionNo = TransactionNo;
                        payTxnReq.ReceiverIDType = ReceiverIDType;
                        payTxnReq.ReceiverIDPlaceOfIssue = dtPayTranReq.ReceiverIDPlaceOfIssue;
                        payTxnReq.ReceiverIDNumber = ReceiverIDNumber;
                        payTxnReq.ReceiverIDExpiryDate = dtPayTranReq.ReceiverIDExpiryDate;


                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                        PayTransactionResponse dtPayTranResp = gccClient.PayTransaction(dtPayTranReq);

                        if (dtPayTranResp.ResponseCode.Equals("001"))
                        {
                            payTxnResp.Successful = dtPayTranResp.Successful;
                            payTxnResp.ResponseCode = dtPayTranResp.ResponseCode;
                            payTxnResp.ResponseMessage = dtPayTranResp.ResponseMessage;
                            payTxnResp.TransactionNo = dtPayTranResp.TransactionNo;
                            payTxnResp.Status = dtPayTranResp.Status;
                            payTxnResp.TransactionDate = dtPayTranResp.TransactionDate;
                            payTxnResp.ReceiveCountryName = dtPayTranResp.ReceiveCountryName;
                            payTxnResp.ReceiveCurrencyCode = dtPayTranResp.ReceiveCurrencyCode;
                            payTxnResp.AmountToPay = dtPayTranResp.AmountToPay.ToString();
                        }
                        else
                        {
                            payTxnResp.Successful = dtPayTranResp.Successful;
                            payTxnResp.ResponseCode = dtPayTranResp.ResponseCode;
                            payTxnResp.ResponseMessage = dtPayTranResp.ResponseMessage;
                        }

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.PayTransaction, isAuthenticated, RequestCode, payTxnReq.toString(), payTxnResp.toString());
                    
                    }// END try
                    catch (Exception Ex)
                    {
                        payTxnResp.ResponseCode = "000";
                        payTxnResp.ResponseCode = Ex.Message;
                        payTxnResp.ResponseMessage = Ex.StackTrace;

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.PayTransaction, isAuthenticated, RequestCode, payTxnResp.ResponseCode, payTxnResp.ResponseMessage);
                    }

                }
            }
            catch (Exception exc)
            {                
                string errorCode = "000 : Technical Error";
                string errorMsg = exc.Message;
                string errorStackTrace = exc.StackTrace;
                LogObj.InsertIntoExHouseAPIErrorLog("PayTransaction", errorCode, errorMsg, errorStackTrace);
            }

            return payTxnResp;
        }


        public BankDepositResponse BankDepositTxn (string securityCode)
        {
            string UniqueID = Global.Definitions.GCCCredentials.credValue.UniqueID;
            string Password = Global.Definitions.GCCCredentials.credValue.Password;
            string SecurityKey = Global.Definitions.GCCCredentials.credValue.SecurityKey;
            string AccountNo = Global.Definitions.GCCCredentials.credValue.AccountNo;

            BankDepositResponse bankDepTxnResp = new BankDepositResponse();
            BankDepositRequest bankDepTxnReq = new BankDepositRequest();

            LogID = 0;
            isAuthenticated = 0;
            string exHouseName = Global.Definitions.ExchangeHouse.ExHName.gcc;

            try
            {
                RequestCode = "SecurityCode:" + securityCode;
                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Bank, isAuthenticated, RequestCode, "", "");

                if (string.Equals(securityCode, secValue.AccessCode))
                {
                    isAuthenticated = 1;
                    RequestCode = "SecurityCode:Passed";
                    LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Bank, isAuthenticated, RequestCode, "", "");

                    try
                    {
                        DisplayTransactionListRequest dspTxnListReq = new DisplayTransactionListRequest();
                        dspTxnListReq.AccountNo = AccountNo;
                        dspTxnListReq.Password = Password;
                        dspTxnListReq.SecurityKey = SecurityKey;
                        dspTxnListReq.UniqueID = UniqueID;

                        bankDepTxnReq.AccountNo = AccountNo;

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                        DisplayTransactionListResponse dtlRsp = gccClient.DisplayTransactionList_Bank(dspTxnListReq);
                        List<DtResultSet> remitObjList = new List<DtResultSet>();
                        DataRow drow;

                        if (dtlRsp.ResponseCode.Equals("001"))
                        {
                            bankDepTxnResp.ResponseCode = dtlRsp.ResponseCode;
                            bankDepTxnResp.ResponseMessage = dtlRsp.ResponseMessage;
                            bankDepTxnResp.Successful = dtlRsp.Successful.ToString();
                            
                            DataSet ds = dtlRsp.dsTransactionList;
                            int cntRec = ds.Tables[0].Rows.Count;                            

                            for (int ii = 0; ii < cntRec; ii++)
                            {
                                DtResultSet remitObj = new DtResultSet();
                                drow = ds.Tables[0].Rows[ii];

                                remitObj.TransactionNo = drow["TransactionNo"].ToString();
                                remitObj.SentDate = Convert.ToDateTime(drow["SentDate"]);
                                remitObj.ValueDate = Convert.ToDateTime(drow["ValueDate"]);
                                remitObj.PayinCountryName = drow["PayinCountryName"].ToString();
                                remitObj.PayinCountryCode = drow["PayinCountryCode"].ToString();
                                remitObj.PayinCurrencyCode = drow["PayinCurrencyCode"].ToString();

                                remitObj.PayinAmount = Convert.ToSingle(drow["PayinAmount"]);
                                remitObj.ExchangeRate = Convert.ToSingle(drow["ExchangeRate"]);
                                remitObj.SenderFirstName = drow["SenderFirstName"].ToString();
                                remitObj.SenderMiddleName = drow["SenderMiddleName"].ToString();
                                remitObj.SenderLastName = drow["SenderLastName"].ToString();
                                remitObj.SenderFullName = drow["SenderFullName"].ToString();
                                remitObj.SenderNationality = drow["SenderNationality"].ToString();
                                remitObj.SenderAddress = drow["SenderAddress"].ToString();
                                remitObj.SenderZipCode = drow["SenderZipCode"].ToString();
                                remitObj.SenderEmail = drow["SenderEmail"].ToString();
                                remitObj.SenderContactNo = drow["SenderContactNo"].ToString();
                                remitObj.SenderIDType = drow["SenderIDType"].ToString();
                                remitObj.SenderIDPlaceOfIssue = drow["SenderIDPlaceOfIssue"].ToString();
                                remitObj.SenderIDNumber = drow["SenderIDNumber"].ToString();
                                remitObj.SenderIDExpiryDate = drow["SenderIDExpiryDate"].ToString();

                                try
                                {
                                    remitObj.SenderOccupation = Utility.OccupationName(Convert.ToInt32(drow["SenderOccupation"]));
                                }
                                catch (Exception conv)
                                {
                                    remitObj.SenderOccupation = drow["SenderOccupation"].ToString();
                                }

                                //remitObj.SenderOccupation = Utility.OccupationName(Convert.ToInt32(drow["SenderOccupation"]));
                                remitObj.SenderIncomeSource = drow["SenderIncomeSource"].ToString();
                                remitObj.Purpose = drow["Purpose"].ToString();
                                remitObj.PayoutCountryName = drow["PayoutCountryName"].ToString();
                                remitObj.PayoutCountryCode = drow["PayoutCountryCode"].ToString();
                                remitObj.PayoutCityName = drow["PayoutCityName"].ToString();
                                remitObj.PayoutLocationName = drow["PayoutLocationName"].ToString();
                                remitObj.PayoutLocationCode = drow["PayoutLocationCode"].ToString();
                                remitObj.PayoutLocationCode2 = drow["PayoutLocationCode2"].ToString();
                                remitObj.PaymentMode = drow["PaymentMode"].ToString();
                                remitObj.PayoutCurrencyCode = drow["PayoutCurrencyCode"].ToString();
                                remitObj.PayoutAmount = Convert.ToSingle(drow["PayoutAmount"].ToString());

                                remitObj.ReceiverFirstName = drow["ReceiverFirstName"].ToString();
                                remitObj.ReceiverMiddleName = drow["ReceiverMiddleName"].ToString();
                                remitObj.ReceiverLastName = drow["ReceiverLastName"].ToString();
                                remitObj.ReceiverFullName = drow["ReceiverFullName"].ToString();
                                remitObj.ReceiverContactNo = drow["ReceiverContactNo"].ToString();
                                remitObj.ReceiverNationality = drow["ReceiverNationality"].ToString();

                                remitObj.BankAccountNo = drow["BankAccountNo"].ToString();
                                remitObj.BankCode = drow["BankCode"].ToString();
                                remitObj.BankName = drow["BankName"].ToString();
                                remitObj.BankBranchName = drow["BankBranchName"].ToString();
                                remitObj.BankBranchCode = drow["BankBranchCode"].ToString();
                                remitObj.BankAddress = drow["BankAddress"].ToString();
                                remitObj.BankZipCode = drow["BankZipCode"].ToString();
                                remitObj.BankCountry = drow["BankCountry"].ToString();
                                remitObj.Status = drow["Status"].ToString();
                                                                
                                remitObjList.Add(remitObj);
                            }

                            bankDepTxnResp.dsTransactionList = remitObjList;
                        }
                        else
                        {
                            bankDepTxnResp.ResponseCode = dtlRsp.ResponseCode;
                            bankDepTxnResp.ResponseMessage = dtlRsp.ResponseMessage;
                            bankDepTxnResp.Successful = dtlRsp.Successful.ToString();
                            bankDepTxnResp.dsTransactionList = remitObjList;
                        }

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Bank, isAuthenticated, RequestCode, bankDepTxnReq.toString(), bankDepTxnResp.toString());
                    
                    }
                    catch (Exception Ex)
                    {
                        bankDepTxnResp.ResponseCode = "000";
                        bankDepTxnResp.ResponseCode = Ex.Message;
                        bankDepTxnResp.ResponseMessage = Ex.StackTrace;

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Bank, isAuthenticated, RequestCode, bankDepTxnResp.ResponseCode, bankDepTxnResp.ResponseMessage);
                    }

                } //if END
            }
            catch (Exception exc)
            {
                string errorCode = "000 : Technical Error";
                string errorMsg = exc.Message;
                string errorStackTrace = exc.StackTrace;
                LogObj.InsertIntoExHouseAPIErrorLog("BankDepositTxn", errorCode, errorMsg, errorStackTrace);
            }

            return bankDepTxnResp;
        }


        public ProcessTransResponse ProcessBankDepositTxn(string securityCode, string TransactionNo)
        {
            string UniqueID = Global.Definitions.GCCCredentials.credValue.UniqueID;
            string Password = Global.Definitions.GCCCredentials.credValue.Password;
            string SecurityKey = Global.Definitions.GCCCredentials.credValue.SecurityKey;

            ProcessTransResponse bankDepProcsTxnResp = new ProcessTransResponse();
            ProcessTransRequest bankDepProcsTxnReq = new ProcessTransRequest();

            LogID = 0;
            isAuthenticated = 0;
            string exHouseName = Global.Definitions.ExchangeHouse.ExHName.gcc;

            try
            {
                RequestCode = "SecurityCode:" + securityCode;
                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.ProcessTransaction, isAuthenticated, RequestCode, "", "");

                if (string.Equals(securityCode, secValue.AccessCode))
                {
                    isAuthenticated = 1;
                    RequestCode = "SecurityCode:Passed";
                    LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.ProcessTransaction, isAuthenticated, RequestCode, "", "");


                    try
                    {
                        ProcessTransactionRequest procTxnReq = new ProcessTransactionRequest();
                        procTxnReq.Password = Password;
                        procTxnReq.SecurityKey = SecurityKey;
                        procTxnReq.TransactionNo = TransactionNo;
                        procTxnReq.UniqueID = UniqueID;

                        bankDepProcsTxnReq.TransactionNo = TransactionNo;

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                        ProcessTransactionResponse procTxnRsp = gccClient.ProcessTransaction(procTxnReq);

                        if (procTxnRsp.ResponseCode.Equals("001"))
                        {
                            bankDepProcsTxnResp.AmountToPay = Convert.ToSingle(procTxnRsp.AmountToPay);
                            bankDepProcsTxnResp.AmountToPayInWords = procTxnRsp.AmountToPayInWords;
                            bankDepProcsTxnResp.ReceiveCountryName = procTxnRsp.ReceiveCountryName;
                            bankDepProcsTxnResp.ReceiveCurrencyCode = procTxnRsp.ReceiveCurrencyCode;
                            bankDepProcsTxnResp.ResponseCode = procTxnRsp.ResponseCode;
                            bankDepProcsTxnResp.ResponseMessage = procTxnRsp.ResponseMessage;
                            bankDepProcsTxnResp.SendCountryCode = procTxnRsp.SendCountryCode;
                            bankDepProcsTxnResp.Status = procTxnRsp.Status;
                            bankDepProcsTxnResp.Successful = procTxnRsp.Successful.ToString();
                            bankDepProcsTxnResp.TransactionDate = procTxnRsp.TransactionDate;
                            bankDepProcsTxnResp.TransactionNo = procTxnRsp.TransactionNo;
                        }
                        else
                        {
                            bankDepProcsTxnResp.Successful = procTxnRsp.Successful.ToString();
                            bankDepProcsTxnResp.ResponseCode = procTxnRsp.ResponseCode;
                            bankDepProcsTxnResp.ResponseMessage = procTxnRsp.ResponseMessage;
                        }

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.ProcessTransaction, isAuthenticated, RequestCode, bankDepProcsTxnReq.toString(), bankDepProcsTxnResp.toString());
                    
                    }
                    catch (Exception Ex)
                    {
                        bankDepProcsTxnResp.ResponseCode = "000";
                        bankDepProcsTxnResp.ResponseCode = Ex.Message;
                        bankDepProcsTxnResp.ResponseMessage = Ex.StackTrace;

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.ProcessTransaction, isAuthenticated, RequestCode, bankDepProcsTxnResp.ResponseCode, bankDepProcsTxnResp.ResponseMessage);
                    }

                }

            }
            catch (Exception exc)
            {
                string errorCode = "000 : Technical Error";
                string errorMsg = exc.Message;
                string errorStackTrace = exc.StackTrace;
                LogObj.InsertIntoExHouseAPIErrorLog("ProcessBankDepositTxn", errorCode, errorMsg, errorStackTrace);
            }

            return bankDepProcsTxnResp;
        }


        public UpdateBankDepositResponse UpdateBankDepositTxnToPaid(string securityCode, string TransactionNo)
        {
            string UniqueID = Global.Definitions.GCCCredentials.credValue.UniqueID;
            string Password = Global.Definitions.GCCCredentials.credValue.Password;
            string SecurityKey = Global.Definitions.GCCCredentials.credValue.SecurityKey;

            UpdateBankDepositResponse updateProcsStatusResp = new UpdateBankDepositResponse();
            UpdateBankDepositRequest updateProcsStatusReq = new UpdateBankDepositRequest();

            LogID = 0;
            isAuthenticated = 0;
            string exHouseName = Global.Definitions.ExchangeHouse.ExHName.gcc;

            try
            {
                RequestCode = "SecurityCode:" + securityCode;
                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.UpdateProcessedStatusToPaid, isAuthenticated, RequestCode, "", "");

                if (string.Equals(securityCode, secValue.AccessCode))
                {
                    isAuthenticated = 1;
                    RequestCode = "SecurityCode:Passed";
                    LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.UpdateProcessedStatusToPaid, isAuthenticated, RequestCode, "", "");


                    try
                    {
                        UpdateProcessedStatusToPaidRequest procTxnReq = new UpdateProcessedStatusToPaidRequest();
                        procTxnReq.Password = Password;
                        procTxnReq.SecurityKey = SecurityKey;
                        procTxnReq.TransactionNo = TransactionNo;
                        procTxnReq.UniqueID = UniqueID;

                        updateProcsStatusReq.TransactionNo = TransactionNo;

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                        UpdateProcessedStatusToPaidResponse procTxnRsp = gccClient.UpdateProcessedStatusToPaid(procTxnReq);

                        if (procTxnRsp.ResponseCode.Equals("001"))
                        {
                            updateProcsStatusResp.ResponseCode = procTxnRsp.ResponseCode;
                            updateProcsStatusResp.ResponseMessage = procTxnRsp.ResponseMessage;
                            updateProcsStatusResp.Status = procTxnRsp.Status;
                            updateProcsStatusResp.Successful = procTxnRsp.Successful.ToString();
                            updateProcsStatusResp.TransactionNo = procTxnRsp.TransactionNo;
                        }
                        else
                        {
                            updateProcsStatusResp.Successful = procTxnRsp.Successful.ToString();
                            updateProcsStatusResp.ResponseCode = procTxnRsp.ResponseCode;
                            updateProcsStatusResp.ResponseMessage = procTxnRsp.ResponseMessage;
                        }

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.UpdateProcessedStatusToPaid, isAuthenticated, RequestCode, updateProcsStatusReq.toString(), updateProcsStatusResp.toString());

                    }
                    catch (Exception Ex)
                    {
                        updateProcsStatusResp.ResponseCode = "000";
                        updateProcsStatusResp.ResponseCode = Ex.Message;
                        updateProcsStatusResp.ResponseMessage = Ex.StackTrace;

                        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.UpdateProcessedStatusToPaid, isAuthenticated, RequestCode, updateProcsStatusResp.ResponseCode, updateProcsStatusResp.ResponseMessage);
                    }

                } // if END

            }
            catch (Exception exc)
            {
                string errorCode = "000 : Technical Error";
                string errorMsg = exc.Message;
                string errorStackTrace = exc.StackTrace;
                LogObj.InsertIntoExHouseAPIErrorLog("UpdateProcessedStatusToPaid", errorCode, errorMsg, errorStackTrace);
            }

            return updateProcsStatusResp;
        }

        //public WalletDepositResponse WalletDepositTxn(string securityCode)
        //{
        //    string UniqueID = Global.Definitions.GCCCredentials.credValue.UniqueID;
        //    string Password = Global.Definitions.GCCCredentials.credValue.Password;
        //    string SecurityKey = Global.Definitions.GCCCredentials.credValue.SecurityKey;
        //    string AccountNo = Global.Definitions.GCCCredentials.credValue.AccountNo;

        //    WalletDepositResponse walletDepTxnResp = new WalletDepositResponse();
        //    WalletDepositRequest walletDepTxnReq = new WalletDepositRequest();

        //    LogID = 0;
        //    isAuthenticated = 0;
        //    string exHouseName = Global.Definitions.ExchangeHouse.ExHName.gcc;

        //    try
        //    {
        //        RequestCode = "SecurityCode:" + securityCode;
        //        LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Cash, isAuthenticated, RequestCode, "", "");

        //        if (string.Equals(securityCode, secValue.AccessCode))
        //        {
        //            isAuthenticated = 1;
        //            RequestCode = "SecurityCode:Passed";
        //            LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Cash, isAuthenticated, RequestCode, "", "");


        //            try
        //            {
        //                DisplayTransactionListRequest dspTxnListReq = new DisplayTransactionListRequest();
        //                dspTxnListReq.AccountNo = AccountNo;
        //                dspTxnListReq.Password = Password;
        //                dspTxnListReq.SecurityKey = SecurityKey;
        //                dspTxnListReq.UniqueID = UniqueID;

        //                walletDepTxnReq.AccountNo = AccountNo;

        //                ServicePointManager.Expect100Continue = true;
        //                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

        //                DisplayTransactionListResponse dtlRsp = gccClient.DisplayTransactionList_Cash(dspTxnListReq);
        //                List<Table> remitObjList = new List<Table>();

        //                if (dtlRsp.ResponseCode.Equals("001"))
        //                {
        //                    walletDepTxnResp.ResponseCode = dtlRsp.ResponseCode;
        //                    walletDepTxnResp.ResponseMessage = dtlRsp.ResponseMessage;
        //                    walletDepTxnResp.Successful = dtlRsp.Successful.ToString();

        //                    DataSet ds = dtlRsp.dsTransactionList;
        //                    int cntRec = ds.Tables[0].Rows.Count;

        //                    for (int ii = 0; ii < cntRec; ii++)
        //                    {
        //                        Table remitObj = new Table();
        //                        Object[] obj = ds.Tables[0].Rows[ii].ItemArray;

        //                        remitObj.TransactionNo = (string)obj[0];
        //                        remitObj.SentDate = Convert.ToDateTime(obj[1]);
        //                        remitObj.ValueDate = Convert.ToDateTime(obj[2]);
        //                        remitObj.PayinCountryName = (string)obj[3];
        //                        remitObj.PayinCountryCode = (string)obj[4];
        //                        remitObj.PayinCurrencyCode = (string)obj[5];
        //                        remitObj.PayinAmount = Convert.ToSingle(obj[6]);
        //                        remitObj.ExchangeRate = Convert.ToSingle(obj[7]);
        //                        remitObj.SenderFirstName = (string)obj[8];
        //                        remitObj.SenderMiddleName = (string)obj[9];
        //                        remitObj.SenderLastName = (string)obj[10];
        //                        remitObj.SenderFullName = (string)obj[12];
        //                        remitObj.SenderNationality = (string)obj[13];
        //                        remitObj.SenderContactNo = (string)obj[14];
        //                        remitObj.SenderIDType = (string)obj[15];
        //                        remitObj.SenderIDPlaceOfIssue = (string)obj[16];
        //                        remitObj.SenderIDNumber = (string)obj[17];
        //                        remitObj.SenderIDExpiryDate = Convert.ToDateTime(obj[18]);
        //                        remitObj.SenderOccupation = Utility.OccupationName((int)obj[19]);
        //                        remitObj.SenderIncomeSource = (string)obj[20];
        //                        remitObj.Purpose = (string)obj[21];
        //                        remitObj.PayoutCountryName = (string)obj[22];
        //                        remitObj.PayoutCountryCode = (string)obj[23];
        //                        remitObj.PayoutCityName = (string)obj[24];
        //                        remitObj.PayoutLocationName = (string)obj[25];
        //                        remitObj.PaymentMode = (string)obj[28];
        //                        remitObj.PayoutCurrencyCode = (string)obj[29];
        //                        remitObj.PayoutAmount = Convert.ToSingle(obj[30]);
        //                        remitObj.ReceiverFirstName = (string)obj[31];
        //                        remitObj.ReceiverMiddleName = (string)obj[32];
        //                        remitObj.ReceiverLastName = (string)obj[33];
        //                        remitObj.ReceiverFullName = (string)obj[35];
        //                        remitObj.ReceiverContactNo = (string)obj[36];
        //                        remitObj.ReceiverNationality = (string)obj[37];
        //                        remitObj.Status = (string)obj[38];

        //                        remitObjList.Add(remitObj);
        //                    }

        //                    walletDepTxnResp.dsTransactionList = remitObjList;
        //                }
        //                else
        //                {
        //                    walletDepTxnResp.ResponseCode = dtlRsp.ResponseCode;
        //                    walletDepTxnResp.ResponseMessage = dtlRsp.ResponseMessage;
        //                    walletDepTxnResp.Successful = dtlRsp.Successful.ToString();
        //                    walletDepTxnResp.dsTransactionList = remitObjList;
        //                }

        //                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Cash, isAuthenticated, RequestCode, walletDepTxnReq.toString(), walletDepTxnResp.toString());

        //            }
        //            catch (Exception Ex)
        //            {
        //                walletDepTxnResp.ResponseCode = "000";
        //                walletDepTxnResp.ResponseCode = Ex.Message;
        //                walletDepTxnResp.ResponseMessage = Ex.StackTrace;

        //                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransactionList_Cash, isAuthenticated, RequestCode, walletDepTxnResp.ResponseCode, walletDepTxnResp.ResponseMessage);
        //            }

        //        }//if END
        //    }
        //    catch (Exception exc)
        //    {
        //        string errorCode = "000 : Technical Error";
        //        string errorMsg = exc.Message;
        //        string errorStackTrace = exc.StackTrace;
        //        LogObj.InsertIntoExHouseAPIErrorLog("WalletDepositTxn", errorCode, errorMsg, errorStackTrace);
        //    }

        //    return walletDepTxnResp;
        //}

        /*
        public DisplayTransactionResponse DisplayTransactionV2(string securityCode, string TransactionNo)
        {
            DisplayTransactionResponse dtResp = new DisplayTransactionResponse();
            string UniqueID = Global.Definitions.GCCCredentials.credValue.UniqueID;
            string Password = Global.Definitions.GCCCredentials.credValue.Password;
            string SecurityKey = Global.Definitions.GCCCredentials.credValue.SecurityKey;  

            LogID = 0;
            isAuthenticated = 0;
            string exHouseName = Global.Definitions.ExchangeHouse.ExHName.gcc;

            try
            {
                RequestCode = "SecurityCode:" + securityCode;
                LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransaction, isAuthenticated, RequestCode, "", "");

                if (string.Equals(securityCode, secValue.AccessCode))
                {
                    isAuthenticated = 1;
                    RequestCode = "SecurityCode:Passed";
                    LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransaction, isAuthenticated, RequestCode, "", "");

                    DisplayTransactionRequest dtReq = new DisplayTransactionRequest();
                    dtReq.Password = Password;
                    dtReq.SecurityKey = SecurityKey;
                    dtReq.TransactionNo = TransactionNo;
                    dtReq.UniqueID = UniqueID;

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                    dtResp = gccClient.DisplayTransaction(dtReq);

                    LogID = LogObj.RQRSLogger(LogID, exHouseName, GCCServiceClassValue.DisplayTransaction, isAuthenticated, RequestCode, dtReq.ToString(), dtResp.ToString());
                }

            }
            catch (Exception exc)
            {
                string errorCode = "E003 : Process Error";
                string errorMsg = exc.Message;
                string errorStackTrace = exc.StackTrace;
                LogObj.InsertIntoExHouseAPIErrorLog("ReceivePayment", errorCode, errorMsg, errorStackTrace);
            }
            
            return dtResp;
        }
        */

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
