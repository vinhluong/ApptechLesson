using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfBankingService
{
    [DataContract]
    public class CustomException
    {
        private string strReason;
        public string Reason
        {
            get { return strReason; }
            set { Reason = value; }
        }
    }
}
