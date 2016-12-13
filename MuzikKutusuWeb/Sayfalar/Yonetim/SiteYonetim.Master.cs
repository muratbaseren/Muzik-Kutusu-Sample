using System;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class SiteYonetim : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeUyelik"] == null || Session["UyeUyelik"].ToString() != "yönetici")
            {
                Response.Redirect("~/Sayfalar/Yonetim/YoneticiGiris.aspx");
            }
        }
    }
}