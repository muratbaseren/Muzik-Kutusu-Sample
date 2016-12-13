using System;
using System.Web;

namespace MuzikKutusuWeb
{
    public partial class Cikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}