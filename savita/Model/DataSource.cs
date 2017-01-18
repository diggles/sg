using Newtonsoft.Json;
using QueryMaster;
using QueryMaster.GameServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Timers;
using System.Web;
using System.Xml;

namespace SavitaAPI.Model
{


    public static class DataSource
    {
        public static GroupInfo GroupInfo;
        public static List<SavitaServer> Servers;

        private static Timer PlayerUpdate;
        private static Timer GroupUpdate;

        public static void Initialise()
        {
            PlayerUpdate = new Timer(30 * 1000);
            GroupUpdate = new Timer(60 * 1000 * 10);

            Servers = new List<SavitaServer> {
                new SavitaServer("103.231.90.20", 27015),
                new SavitaServer("103.231.91.66", 27025)
            };

            GroupInfo = new GroupInfo();

            PlayerUpdate.Elapsed += (object o, ElapsedEventArgs e) => Servers.ForEach(s => s.Update());
            PlayerUpdate.Enabled = true;

            GroupUpdate.Elapsed += (object timer, ElapsedEventArgs timerArgs) => GroupInfo.Update();
            GroupUpdate.Enabled = true;
        }
        
    }
}