using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;


namespace HostYael
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost service = new ServiceHost(typeof(ServerYaelReichenberg.Service1));
            service.Open();
            Console.ReadLine();
        }
    }
}
