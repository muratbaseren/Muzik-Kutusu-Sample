using System;
using System.Data;

namespace MuzikKutusuWeb.Sayfalar.Yonetim
{
    public partial class UyeListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();

            DataTable uyeListesi = yardimci.UyeListesiGetir();
            this.rptUyeler.DataSource = uyeListesi;
            this.rptUyeler.DataBind();

        }
    }
}