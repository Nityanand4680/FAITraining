using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class PostBackFeature : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstData.Items.Add("Apples");
                lstData.Items.Add("PineApples");
                lstData.Items.Add("Ooty Apples");
                lstData.Items.Add("Kashmir Apples");
                lstData.Items.Add("Shimla Apples");
            }
        }

        protected void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("ListBox Item " + lstData.SelectedItem.Text + " was selected");
        }
    }
}