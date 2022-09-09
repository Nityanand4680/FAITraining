using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Session is an object of a class called HttpSession that represents an unique interaction b/w the instance of the browser and the server. Every session created will have a unique ID called as Session ID. 
namespace SampleWebFormApp
{
    public partial class SessionDemo : System.Web.UI.Page
    {
        static Dictionary<string, string> myData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Application["MyWords"] == null)
            {
                myData = new Dictionary<string, string>();
            }
            else
            {
                myData = Application["MyWords"] as Dictionary<string, string>;
                grdWords.DataSource = myData;
                grdWords.DataBind();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            myData[txtWord.Text] = txtMeaning.Text;
            Application["MyWords"] = myData;
            grdWords.DataSource = myData;
            grdWords.DataBind();
        }
    }
}