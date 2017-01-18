using QueryMaster;
using QueryMaster.GameServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SavitaAPI.Model
{
    public class SavitaServer
    {
        public ServerInfo ServerInfo;
        public QueryMasterCollection<PlayerInfo> Players;
        private Server Server;

        public SavitaServer(string ip, ushort port)
        {
            Server = ServerQuery.GetServerInstance(EngineType.Source, ip, port);
            Update();
        }

        public void Update()
        {
            ServerInfo = Server.GetInfo();
            Players = Server.GetPlayers();
        }
    }
}