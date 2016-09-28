using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace ASPNETWcfServiceNoConfig
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("MyService", new MyServiceHostFactory(), typeof(ASPNETWcfServiceNoConfig.MyService)));
        }
    }
}