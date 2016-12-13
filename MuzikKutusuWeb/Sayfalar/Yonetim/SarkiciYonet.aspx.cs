using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class SarkiciYonet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"]);
                    VeritabaniYardimci yardimci = new VeritabaniYardimci();
                    DataTable sarkici = yardimci.SarkiciGetir(id);

                    this.rptSarkici.DataSource = sarkici;
                    this.rptSarkici.DataBind();
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                string ad = (this.rptSarkici.Controls[0].FindControl("txtSarkici") as TextBox).Text;
                string twitter = (this.rptSarkici.Controls[0].FindControl("txtSarkiciTwitter") as TextBox).Text;

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                bool sonuc = yardimci.SarkiciDuzenle(ad, twitter, id);

                if (sonuc)
                    Response.Redirect("~/Sayfalar/Yonetim/SarkicilariYonet.aspx");
                else
                {
                    this.lblUyari.Text = "Şarkıcı kaydedilemedi.";
                    this.lblUyari.Visible = true;
                }

            }
        }
    }
}