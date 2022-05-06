using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace WcfBankingService
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankingService" in both code and config file together.
   /* [ServiceBehavior(
     ConcurrencyMode = ConcurrencyMode.Single,
     InstanceContextMode = InstanceContextMode.PerSession,
     ReleaseServiceInstanceOnTransactionComplete = false,
     TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
     TransactionTimeout = "00:00:05"
   )]*/
    [ServiceBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BankingService : IBankingService
    {

        public double Deposit(double amount)
        {

            throw new NotImplementedException();
        }
        //[OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]

        public double ShowBalanceWithTimeOut(string accno)
        {
            //SBI1
            Thread.Sleep((int)TimeSpan.FromSeconds(10).TotalMilliseconds);
            var cn = new BankDAO();
            var connection = cn.ConnectDB();
            var table = cn.ExecuteQuery(connection, "select * from BankAccounts where accno ='" + accno + "'");
            if (table.Tables.Count > 0 && table.Tables[0].Rows.Count > 0)
            {
                return double.Parse(table.Tables[0].Rows[0]["accamount"].ToString());
            }
            return -1;
        }
        public double ShowBalance(string accno)
        {
            //SBI1
            var cn = new BankDAO();
            var connection = cn.ConnectDB();
            var table = cn.ExecuteQuery(connection, "select * from BankAccounts where accno ='" + accno + "'");
            if (table.Tables.Count > 0 && table.Tables[0].Rows.Count > 0)
            {
                return double.Parse(table.Tables[0].Rows[0]["accamount"].ToString());
            }
            return -1;
        }


        public double WithDraw(double amount)
        {
            throw new NotImplementedException();
        }
        public BankAccount GetBankAccount(string accno)
        {
            var bankAccount = new BankAccount();
            var cn = new BankDAO();
            var connection = cn.ConnectDB();
            var table = cn.ExecuteQuery(connection, "select * from BankAccounts where accno ='" + accno + "'");
            if (table.Tables.Count > 0 && table.Tables[0].Rows.Count > 0)
            {
                bankAccount.AccNo = table.Tables[0].Rows[0]["accno"].ToString();
                bankAccount.AccFname = table.Tables[0].Rows[0]["accfname"].ToString();
                bankAccount.AccActive = int.Parse(table.Tables[0].Rows[0]["accactive"].ToString());
                bankAccount.AccAmount = double.Parse(table.Tables[0].Rows[0]["accamount"].ToString());
            }
            return bankAccount;
        }
        public string GetBankAccountJson(string accno)
        {
            var bankAccount = new BankAccount();
            var cn = new BankDAO();
            var connection = cn.ConnectDB();
            var table = cn.ExecuteQuery(connection, "select * from BankAccounts where accno ='" + accno + "'");
            if (table.Tables.Count > 0 && table.Tables[0].Rows.Count > 0)
            {
                bankAccount.AccNo = table.Tables[0].Rows[0]["accno"].ToString();
                bankAccount.AccFname = table.Tables[0].Rows[0]["accfname"].ToString();
                bankAccount.AccActive = int.Parse(table.Tables[0].Rows[0]["accactive"].ToString());
                bankAccount.AccAmount = double.Parse(table.Tables[0].Rows[0]["accamount"].ToString());
            }
            return (new JavaScriptSerializer().Serialize(bankAccount));
            
        }
    }
}
