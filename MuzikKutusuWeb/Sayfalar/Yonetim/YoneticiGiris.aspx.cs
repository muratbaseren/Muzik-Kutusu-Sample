using System;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string eposta = this.txtEPosta.Text;
            string sifre = this.txtSifre.Text;

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            bool sonuc = yardimci.YoneticiGiris(eposta, sifre);

            if (sonuc)
            {
                Response.Redirect("~/Sayfalar/Yonetim/YoneticiPaneli.aspx");
            }
            else
            {
                this.lblUyari.Text = "Yanlış E-Posta/Şifre veya üyelik türünüz 'yönetici' olarak ayarlanmamıştır.";
                this.lblUyari.Visible = true;
            }
        }
    }
}