using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quartzite;

namespace QuartziteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IrcServicesConfig conf = new IrcServicesConfig("192.168.0.156",7092,"password","test.services.seersirc.net","42","A test for the framework yo!","Quartzite version Something");
            conf.Ssl = false;
            IrcServices serv = new IrcServices(conf);
            serv.Connect();
            serv.Run();

        }
    }
}
