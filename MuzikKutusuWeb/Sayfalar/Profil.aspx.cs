using System;
using System.Web;
using System.Web.UI;

namespace MuzikKutusuWeb
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtAdiniz.Text = HttpContext.Current.Session["UyeAd"].ToString();
                this.txtSoyadiniz.Text = HttpContext.Current.Session["UyeSoyad"].ToString();
                this.txtEPosta.Text = HttpContext.Current.Session["UyeEPosta"].ToString();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            int id = (int)Session["UyeID"];
            string ad = this.txtAdiniz.Text;
            string soyad = this.txtSoyadiniz.Text;
            string eposta = this.txtEPosta.Text;
            string sifre = this.txtSifre.Text;
            string uyelik = "üye";

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            bool sonuc = yardimci.UyeDuzenle(ad, soyad, eposta, sifre, uyelik, id);

            if (sonuc)
            {
                HttpContext.Current.Session["UyeID"] = id;
                HttpContext.Current.Session["UyeAd"] = ad;
                HttpContext.Current.Session["UyeSoyad"] = soyad;
                HttpContext.Current.Session["UyeEPosta"] = eposta;
                HttpContext.Current.Session["UyeUyelik"] = uyelik;

                Response.Redirect("~/Default.aspx");
            }
            else
            {
                this.lblUyari.Text = "Profil güncellenemedi..";
                this.lblUyari.Visible = true;
            }
        }
    }
}