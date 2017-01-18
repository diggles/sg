using SavitaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SavitaAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class GroupController : ApiController
    {
        // GET api/values
        public GroupInfo Get()
        {
            return DataSource.GroupInfo;
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