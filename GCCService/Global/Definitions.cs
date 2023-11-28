using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCService.Global.Definitions.webServiceUrl
{
    public sealed class serviceUrlValue
    {
        public const string serviceUrl = "https://api.gccremit.com/ReceiveAPI.svc?wsdl";
        public const string ProxyHost = @"192.168.51.51";
        public const int ProxyPort = 80;
    }
}

namespace GCCService.Global.Definitions.securityCode
{
    public sealed class secValue
    {
        public const string AccessCode = "GCC@@#@#1008001";

    }
}

namespace GCCService.Global.Definitions.GCCCredentials
{
    public sealed class credValue
    {
        public const string UniqueID = "09838784";
        public const string Password = "delta1234";
        public const string SecurityKey = "tuhVJIkMhs+rHRMz987654";
        public const string AccountNo = "0919565900";
    }
}

namespace GCCService.Global.Definitions.ExchangeHouse
{
    public sealed class ExHName
    {
        public const string gcc = "GCCRemit";
    }
}

namespace GCCService.Global.Definitions.ServiceID
{
    public sealed class GCCServiceClassValue
    {
        public const int DisplayTransaction = 1;  // for cash data fetch
        public const int PayTransaction = 2;      // for cash data confirm
        public const int DisplayTransactionList_Bank = 3;   // for bank deposit fetch
        public const int ProcessTransaction = 4;    // for bank deposit processed mark
        public const int UpdateProcessedStatusToPaid = 5;   // for bank deposit status change
        public const int DisplayTransactionList_Cash = 6;   // for wallet deposit fetch
    }
}