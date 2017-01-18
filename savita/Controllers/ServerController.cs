using QueryMaster.GameServer;
using SavitaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SavitaAPI.Controllers
{

    public class ServerController : ApiController
    {
        // GET api/values
        public object Get()
        {
            return DataSource.Servers;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}