using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace WcfBankingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankingService" in both code and config file together.

    [ServiceContract( SessionMode = SessionMode.Required)]

    public interface IBankingService
    {
        [OperationContract]
        double WithDraw(double amount);
        [OperationContract]
        double Deposit(double amount);
        [OperationContract]
        double ShowBalance(string accno);
        [OperationContract]
        double ShowBalanceWithTimeOut(string accno);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        BankAccount GetBankAccount(string accno);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string GetBankAccountJson(string accno);
        //MessageContract
        [OperationContract]
        BankAccountResponse GetBankAccountMessageContract(BankAccountRequest Req);


       
    }
}
