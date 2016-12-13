using System;
using System.Data;
using System.Web.UI;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class SarkilariYonet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SarkicilarYukle();
                this.MuzikTurleriYukle();
                this.SarkilarYukle();
            }

            this.SarkiSilmeKontrol();
        }

        private void MuzikTurleriYukle()
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable muzikTurleri = yardimci.MuzikTurleriGetir();
            this.cmbMuzikTuru.DataSource = muzikTurleri;
            this.cmbMuzikTuru.DataValueField = "ID";
            this.cmbMuzikTuru.DataTextField = "TurAd";
            this.cmbMuzikTuru.DataBind();
        }

        private void SarkicilarYukle()
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable sarkicilar = yardimci.SarkicilarGetir();
            this.cmbSarkici.DataSource = sarkicilar;
            this.cmbSarkici.DataValueField = "ID";
            this.cmbSarkici.DataTextField = "SarkiciAd";
            this.cmbSarkici.DataBind();
        }

        private void SarkiSilmeKontrol()
        {
            if (Request.QueryString["Sil"] != null && Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                int sil = int.Parse(Request.QueryString["Sil"]);

                if (sil == 1)
                {
                    VeritabaniYardimci yardimci = new VeritabaniYardimci();
                    bool silindi = yardimci.SarkiSil(id);

                    if (silindi)
                    {
                        Response.Redirect("~/Sayfalar/Yonetim/SarkilariYonet.aspx");
                    }
                    else
                    {
                        this.lblUyari.Text = "Şarkı silinemedi !";
                        this.lblUyari.Visible = true;
                    }
                }
            }
        }

        private void SarkilarYukle()
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable sarkilar = yardimci.SarkilarGetir();
            this.rptSarkilar.DataSource = sarkilar;
            this.rptSarkilar.DataBind();
        }

        protected void btnSarkiEkle_Click(object sender, EventArgs e)
        {
            string ad = this.txtSarki.Text;
            int sarkiciId = int.Parse(this.cmbSarkici.SelectedValue);
            int muzikTuruId = int.Parse(this.cmbMuzikTuru.SelectedValue);

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            bool sonuc = yardimci.SarkiEkle(ad, sarkiciId, muzikTuruId);

            if (sonuc)
            {
                this.SarkilarYukle();
            }
            else
            {
                this.lblUyari.Text = "Şarkı eklenemedi !";
                this.lblUyari.Visible = true;
            }
        }
    }
}