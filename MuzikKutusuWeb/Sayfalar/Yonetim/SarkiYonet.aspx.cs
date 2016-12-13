using System;
using System.Data;
using System.Web.UI;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class SarkiYonet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SarkicilarYukle();
                this.MuzikTurleriYukle();

                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"]);
                    VeritabaniYardimci yardimci = new VeritabaniYardimci();
                    DataTable sarkici = yardimci.SarkiGetir(id);

                    if (sarkici.Rows.Count > 0)
                    {
                        this.txtSarki.Text = sarkici.Rows[0]["SarkiAd"].ToString();
                        this.cmbSarkici.SelectedValue = sarkici.Rows[0]["SarkiciID"].ToString();
                        this.cmbMuzikTuru.SelectedValue = sarkici.Rows[0]["MuzikTuruID"].ToString();
                    }
                }
            }
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

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                string ad = this.txtSarki.Text;
                int sarkiciId = int.Parse(this.cmbSarkici.SelectedValue);
                int muzikTuruId = int.Parse(this.cmbMuzikTuru.SelectedValue);

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                bool sonuc = yardimci.SarkiDuzenle(ad, sarkiciId, muzikTuruId, id);

                if (sonuc)
                    Response.Redirect("~/Sayfalar/Yonetim/SarkilariYonet.aspx");
                else
                {
                    this.lblUyari.Text = "Şarkı kaydedilemedi.";
                    this.lblUyari.Visible = true;
                }
            }
        }
    }
}