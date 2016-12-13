using System;

namespace MuzikKutusuWeb
{
    public partial class UyeOl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUyeOl_Click(object sender, EventArgs e)
        {
            string eposta = this.txtEPosta.Text;
            string sifre = this.txtSifre.Text;

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            bool sonuc = yardimci.UyeKayit(eposta, sifre);

            if (sonuc)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                this.lblUyari.Text = "Üyelik kaydedilemedi..";
                this.lblUyari.Visible = true;
            }

        }
    }
}