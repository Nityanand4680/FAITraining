using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class QueryStringDemo : System.Web.UI.Page
    {

        public TextBox Content1
        {
            get { return txtInput; }
        }

        public TextBox Content2
        {
            get { return txtInput2; }
        }

        public TextBox Content3
        {
            get { return txtInput3; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            /****************Sending info thru Query String****************
            string url = String.Format("RecipientPage.aspx?First={0}&Second={1}&Third={2}" ,txtInput.Text, txtInput2.Text, txtInput3.Text);
            Response.Redirect(url);
            ***************Sending Info in the form of Cookies************
            HttpCookie cookie = new HttpCookie("Data");
            cookie.Values.Add("First", txtInput.Text);
            cookie.Values.Add("Second", txtInput2.Text);
            cookie.Values.Add("Third", txtInput3.Text);
            Response.Cookies.Add(cookie);
            Response.Redirect("RecipientPage.aspx");
            *****************Cross Page posting********************/

        }
    }
}