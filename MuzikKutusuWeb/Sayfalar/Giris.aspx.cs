using System;

namespace MuzikKutusuWeb
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string eposta = this.txtEPosta.Text;
            string sifre = this.txtSifre.Text;

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            bool sonuc = yardimci.UyeGiris(eposta, sifre);

            if (sonuc)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                this.lblUyari.Text = "Yanlış E-Posta ya da Şifre";
                this.lblUyari.Visible = true;
            }
        }
    }
}