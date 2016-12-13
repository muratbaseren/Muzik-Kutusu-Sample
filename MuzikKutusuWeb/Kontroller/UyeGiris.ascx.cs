using System;

namespace MuzikKutusuWeb
{
    public partial class UyeGiris : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeID"] != null)
            {
                this.uyelikGiris.Visible = false;
                this.uyeBilgi.Visible = true;

                this.lnkProfil.InnerText = Session["UyeAd"].ToString() + " " + Session["UyeSoyad"].ToString();
            }
        }
    }
}