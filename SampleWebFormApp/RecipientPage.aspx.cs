using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormApp
{
    public partial class RecipientPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string name = String.Format("The First: {0}<br/>The second: {1}<br/>The Third: {2}", Request.QueryString["First"], Request["Second"], Request["Third"]);
            //if (Request.Cookies["Data"] == null)
            //    return;
            //string first = Request.Cookies["Data"]["First"];
            //string second = Request.Cookies["Data"]["Second"];
            //string third = Request.Cookies["Data"]["Third"];
            //string content = $"The First: {first}<br/>The Second: {second}<br/>The Third: {third}";
            //lblData.Text = "The Posted Info: <br/>" + content;
            /*Limitations of query string: 
             * User can see the data in the URL and modify. 
             * U can only share text thru the URL.
             * Some browsers restrict the length of the URL upto 255 charecters. 
             */

            /*
             * Cookies are text based files that are stored in the client browser for a default period of 1 year. These are plain text files and are harmless. 
             * Cookies are mainly dependent on the user preferences. Users can disable the cookies and can delete them any time. 
             * So any info that is very important for the Web App should not be stored in cookies, or else U should provide the alternate data for it. 
             * Unlike QueryString, cookies are hidden and the data is not available for the users directly. Query Strings are used to transfer data from one page to another specific page. But cookies once created, can be used in any no of pages of the Application. 
             */
            //All elements of a Page are private to the page. 
            //string content = PreviousPage.Content1.Text;
            if(PreviousPage == null || !IsCrossPagePostBack)
            {
                return;
            }
            string content = (PreviousPage.FindControl("txtInput") as TextBox).Text;
            string content2 = PreviousPage.Content2.Text;
            string content3 = PreviousPage.Content3.Text;
            string allContent = string.Format("The First: {0}<br/>The Second:{1}<br/>The Third:{2}", content, content2, content3);
            lblData.Text = allContent;
        }
    }
}