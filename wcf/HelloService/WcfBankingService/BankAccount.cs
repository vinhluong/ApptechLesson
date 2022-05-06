using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfBankingService
{
    [DataContract]
    public class BankAccount
    {
        [DataMember]
        public string AccNo { get; set; }
        [DataMember]
        public string AccFname { get; set; }
        public double AccAmount { get; set; }
        public int AccActive { get; set; }
        public BankAccount() { }
        public  BankAccount(string AccNo, string AccFname, double AccAmount, int AccActive){
            AccNo = AccNo;
            AccFname = AccFname;
            AccAmount = AccAmount;
            AccActive = AccActive;
        }
    }
}
