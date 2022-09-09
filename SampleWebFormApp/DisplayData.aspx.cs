using SampleWebFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class DisplayData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Total Users: " + (Application["TotalUsers"]));
            if (!IsPostBack)
            {
                rpProducts.DataSource = Application["Products"] as List<Product>;
                rpProducts.DataBind();
            }
        }

        protected void rpProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "addToCart")
            {
                var id = e.CommandArgument;
                var list = Application["Products"] as List<Product>;
                var item = list.Find((i) => i.ProductId.ToString() == id.ToString());
                var cart = Session["myCart"] as List<Product>;
                if (item != null) cart.Add(item);
                else Response.Write("No Item is found");
                grdCart.DataSource = cart;
                grdCart.DataBind();
                Session["myCart"] = cart;
            }
        }
    }
}