using System;
using System.Data;
using System.Web.UI;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class SarkicilariYonet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SarkicilarYukle();
            }

            this.SarkiciSilmeKontrol();
        }

        private void SarkicilarYukle()
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable sarkicilar = yardimci.SarkicilarGetir();
            this.rptSarkicilar.DataSource = sarkicilar;
            this.rptSarkicilar.DataBind();
        }

        private void SarkiciSilmeKontrol()
        {
            if (Request.QueryString["Sil"] != null && Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                int sil = int.Parse(Request.QueryString["Sil"]);

                if (sil == 1)
                {
                    VeritabaniYardimci yardimci = new VeritabaniYardimci();
                    bool silindi = yardimci.SarkiciSil(id);

                    if (silindi)
                    {
                        Response.Redirect("~/Sayfalar/Yonetim/SarkicilariYonet.aspx");
                    }
                    else
                    {
                        this.lblUyari.Text = "Şarkıcı silinemedi !";
                        this.lblUyari.Visible = true;
                    }
                }
            }
        }

        protected void btnSarkiciEkle_Click(object sender, EventArgs e)
        {
            string ad = this.txtSarkici.Text;
            string twitter = this.txtSarkiciTwitter.Text;

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            bool sonuc = yardimci.SarkiciEkle(ad, twitter);

            if (sonuc)
            {
                this.SarkicilarYukle();
            }
            else
            {
                this.lblUyari.Text = "Şarkıcı eklenemedi !";
                this.lblUyari.Visible = true;
            }
        }
    }
}