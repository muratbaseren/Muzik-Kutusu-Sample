using System;
using System.Data;
using System.Web.UI;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class MuzikTurleriYonet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.MuzikTurleriYukle();
            }

            this.MuzikTuruSilmeKontrol();
        }

        private void MuzikTuruSilmeKontrol()
        {
            if (Request.QueryString["Sil"] != null && Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                int sil = int.Parse(Request.QueryString["Sil"]);

                if (sil == 1)
                {
                    VeritabaniYardimci yardimci = new VeritabaniYardimci();
                    bool silindi = yardimci.MuzikTuruSil(id);

                    if (silindi)
                    {
                        Response.Redirect("~/Sayfalar/Yonetim/MuzikTurleriYonet.aspx");
                    }
                    else
                    {
                        this.lblUyari.Text = "Müzik türü silinemedi !";
                        this.lblUyari.Visible = true;
                    }
                }
            }
        }

        private void MuzikTurleriYukle()
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable muzikTurleri = yardimci.MuzikTurleriGetir();
            this.rptMuzikTurleri.DataSource = muzikTurleri;
            this.rptMuzikTurleri.DataBind();
        }

        protected void btnMuzikTuruEkle_Click(object sender, EventArgs e)
        {
            string turAd = this.txtMuzikTuru.Text;
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            bool sonuc = yardimci.MuzikTuruEkle(turAd);

            if (sonuc)
            {
                this.MuzikTurleriYukle();
            }
            else
            {
                this.lblUyari.Text = "Müzik türü eklenemedi !";
                this.lblUyari.Visible = true;
            }
        }
    }
}