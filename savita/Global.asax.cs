using SavitaAPI.App_Start;
using SavitaAPI.Formatters;
using SavitaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SavitaAPI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;
            config.Formatters.Insert(0, new JsonpMediaTypeFormatter());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            DataSource.Initialise();
        }
    }
}