using SampleWebFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleWebFormApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Products"] = ProductRepo.Products;
            Application["TotalUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            int count = (int)Application["TotalUsers"];
            Application["TotalUsers"] = ++count;

            Session["myCart"] = new List<Product>();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}