using GCCService.GCCServiceReference;
using GCCService.ResponseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GCCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGCCService
    {
        [OperationContract]
        CashTxnResponse DisplayTransaction(string securityCode, string TransactionNo);

        [OperationContract]
        PayTranResponses PayTransaction(string securityCode, string TransactionNo, string ReceiverIDType, string ReceiverIDNumber);

        [OperationContract]
        BankDepositResponse BankDepositTxn(string securityCode);

        [OperationContract]
        ProcessTransResponse ProcessBankDepositTxn(string securityCode, string TransactionNo);

        [OperationContract]
        UpdateBankDepositResponse UpdateBankDepositTxnToPaid(string securityCode, string TransactionNo);

        //[OperationContract]
        //WalletDepositResponse WalletDepositTxn(string securityCode);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
