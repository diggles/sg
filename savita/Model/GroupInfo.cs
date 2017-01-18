using Newtonsoft.Json;
using SavitaAPI.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Xml;

namespace SavitaAPI.Model
{
    public class GroupInfo
    {
        public long groupID64;
        public GroupDetails groupDetails;
        public int memberCount;
        public int totalPages;
        public int currentPage;
        public int startingMember;
        public MemberIds members;
        public List<User> users;

        public GroupInfo()
        {
            Update();
        }

        public void PopulateMembers()
        {
            users = new List<User>();
            WebClient http = new WebClient();
            members.steamID64.ToList().ForEach(memberId => {

                string userXml = string.Empty;
                User u = null;

                try
                {
                    userXml = http.DownloadString(new Uri("http://steamcommunity.com/profiles/" + memberId + "/?xml=1"));
                    u = GetXmlAsObject<User>(userXml);
                }
                catch
                {
                    return;
                }

                

                if (u == null) return;

                users.Add(u);
            });
                
         
            Console.WriteLine("Users loaded");
        }

        public void Update()
        {
            WebClient http = new WebClient();
            http.DownloadStringCompleted += (object httpClient, DownloadStringCompletedEventArgs downloadArgs) => {
                if (downloadArgs.Error != null) return;

                Update(GetXmlAsObject<GroupInfo>(downloadArgs.Result));


                Console.WriteLine("Group loaded, updating users");

                PopulateMembers();
            };

            http.DownloadStringAsync(new Uri("http://steamcommunity.com/groups/SavitaGaming/memberslistxml?xml=1"));
        }

        private void Update(GroupInfo groupInfo)
        {
            groupID64 = groupInfo.groupID64;
            groupDetails = groupInfo.groupDetails;
            memberCount = groupInfo.memberCount;
            totalPages = groupInfo.totalPages;
            currentPage = groupInfo.currentPage;
            startingMember = groupInfo.startingMember;
            members = groupInfo.members;
            users = groupInfo.users;

        }

        public static T GetXmlAsObject<T>(string xml)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(xml.Remove(0, 55));
            }
            catch
            {
                Console.WriteLine("Steam Error");
            }
            string jsonDocument = JsonConvert.SerializeXmlNode(xmlDocument, Newtonsoft.Json.Formatting.None, true);
            return JsonConvert.DeserializeObject<T>(jsonDocument);

        }
    }

    public class GroupDetails
    {
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData groupName;
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData groupURL;
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData headline;
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData summary;
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData avatarIcon;
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData avatarMedium;
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData avatarFull;

        public int memberCount;
        public int membersInChat;
        public int membersInGame;
        public int membersOnline;

    }

    public class CData
    {
        [JsonProperty("#cdata-section")]
        public string data;

        public override string ToString()
        {
            return data;
        }
    }

    public class MemberIds
    {
        public long[] steamID64;
    }

    public class User
    {
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData steamID;
        [JsonConverter(typeof(ToStringJsonConverter))]
        public CData avatarMedium;
        
        public string inGameServerIP;

        public string onlineState;
        
        public string OnlineClass { get { return inGameServerIP == "103.231.90.20:27015" ? "savita" : onlineState; } }



    }
}