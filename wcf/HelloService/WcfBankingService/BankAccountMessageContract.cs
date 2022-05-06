using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBankingService
{
    [MessageContract]
    public class BankAccountRequest
    {
        [MessageHeader()]
        public string AuthCode;
        [MessageHeader]
        public string AccNo;
    }
    [MessageContract]
    public class BankAccountResponse
    {
        [MessageBodyMember]
        public BankAccount Obj { get; set; }
        [MessageHeader]
        public string Message { get; set; }
        [MessageHeader]
        public int Code { get; set; }
        [MessageHeader]
        public bool IsError { get; set; }
    }
   
}
