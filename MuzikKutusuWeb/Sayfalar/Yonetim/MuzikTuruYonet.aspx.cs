using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class MuzikTuruYonet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"]);
                    VeritabaniYardimci yardimci = new VeritabaniYardimci();
                    DataTable muzikTuru = yardimci.MuzikTuruGetir(id);

                    this.rptMuzikTuru.DataSource = muzikTuru;
                    this.rptMuzikTuru.DataBind();
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                string turAd = (this.rptMuzikTuru.Controls[0].FindControl("txtMuzikTuru") as TextBox).Text;

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                bool sonuc = yardimci.MuzikTuruDuzenle(turAd, id);

                if (sonuc)
                    Response.Redirect("~/Sayfalar/Yonetim/MuzikTurleriYonet.aspx");
                else
                {
                    this.lblUyari.Text = "Müzik türü kaydedilemedi.";
                    this.lblUyari.Visible = true;
                }

            }
        }
    }
}