using System;
using System.Web.Http;
using WebApiExample.Models;

namespace WebApiExample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Book.RegisterClassMap();
        }
    }
}