using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class UyeYonet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["uyeID"]))
                {
                    int id = int.Parse(Request.QueryString["uyeID"]);

                    VeritabaniYardimci yardimci = new VeritabaniYardimci();
                    DataTable uye = yardimci.UyeGetir(id);

                    this.rptUye.DataSource = uye;
                    this.rptUye.DataBind();

                    if (uye.Rows.Count > 0)
                    {
                        this.cmbUyelikTuru.SelectedValue = uye.Rows[0]["UyelikTuru"].ToString();
                    }
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["uyeID"]))
            {
                int id = int.Parse(Request.QueryString["uyeID"]);
                string ad = (this.rptUye.Controls[0].FindControl("txtAdiniz") as TextBox).Text;
                string soyad = (this.rptUye.Controls[0].FindControl("txtSoyadiniz") as TextBox).Text;
                string eposta = (this.rptUye.Controls[0].FindControl("txtEPosta") as TextBox).Text;
                string sifre = (this.rptUye.Controls[0].FindControl("txtSifre") as TextBox).Text;
                string uyelikTuru = this.cmbUyelikTuru.SelectedValue;

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                bool sonuc = yardimci.UyeDuzenle(ad, soyad, eposta, sifre, uyelikTuru, id);

                if (sonuc)
                {
                    Response.Redirect("~/Sayfalar/Yonetim/UyeListesi.aspx");
                }
                else
                {
                    this.lblUyari.Text = "Üye bilgisi güncellenemedi..";
                    this.lblUyari.Visible = true;
                }
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["uyeID"]))
            {
                int id = int.Parse(Request.QueryString["uyeID"]);

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                bool sonuc = yardimci.UyeSil(id);

                if (sonuc)
                    Response.Redirect("~/Sayfalar/Yonetim/UyeListesi.aspx");
                else
                {
                    this.lblUyari.Text = "Üye silinirken bir hata oluştu.";
                    this.lblUyari.Visible = true;
                }
            }
        }
    }
}