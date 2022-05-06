using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using HelloService;
namespace HelloServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloService.HelloService)))
            {
                /*host.Open();
                Console.WriteLine("HelloService started @" + DateTime.Now.ToString());
                Console.ReadLine();*/
            }
            using (ServiceHost hostBankingService = new ServiceHost(typeof(WcfBankingService.BankingService)))
            {
                hostBankingService.Open();
                Console.WriteLine("BankingService started @" + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
