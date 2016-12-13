using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuzikKutusuWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SarkicilarYukle(cmbSarkicilar1);
                this.MuzikTurleriYukle(cmbMuzikTuru1);
            }

            this.FavorilerYukle();
        }

        private void FavorilerYukle()
        {
            if (Session["UyeID"] != null)
            {
                int uyeId = int.Parse(Session["UyeID"].ToString());

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                DataTable favoriler = yardimci.FavorilerGetir(uyeId);
                this.rptFavoriler.DataSource = favoriler;
                this.rptFavoriler.DataBind();
            }
            else
            {
                this.lblFavoriUyari.Text = "Favori listenizi görmek için kaydolun ya da giriş yapın.";
                this.lblFavoriUyari.Visible = true;
            }
        }

        private void MuzikTurleriYukle(DropDownList dropdown)
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable muzikTurleri = yardimci.MuzikTurleriGetir();
            dropdown.DataSource = muzikTurleri;
            dropdown.DataValueField = "ID";
            dropdown.DataTextField = "TurAd";
            dropdown.DataBind();
        }

        private void SarkicilarYukle(DropDownList dropdown)
        {
            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable sarkicilar = yardimci.SarkicilarGetir();
            dropdown.DataSource = sarkicilar;
            dropdown.DataValueField = "ID";
            dropdown.DataTextField = "SarkiciAd";
            dropdown.DataBind();
        }

        protected void btnFiltrele1_Click(object sender, EventArgs e)
        {
            int sarkiciId = int.Parse(this.cmbSarkicilar1.SelectedValue);

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable sonuclar = yardimci.FiltreleSarkiciyaGore(sarkiciId);
            this.rptSonuclar.DataSource = sonuclar;
            this.rptSonuclar.DataBind();
        }

        protected void btnFiltrele2_Click(object sender, EventArgs e)
        {
            int muzikTuruId = int.Parse(this.cmbMuzikTuru1.SelectedValue);

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable sonuclar = yardimci.FiltreleMuzikTuruneGore(muzikTuruId);
            this.rptSonuclar.DataSource = sonuclar;
            this.rptSonuclar.DataBind();
        }

        protected void btnFiltrele3_Click(object sender, EventArgs e)
        {
            string filtre = this.txtFiltre3.Text;

            VeritabaniYardimci yardimci = new VeritabaniYardimci();
            DataTable sonuclar = yardimci.FiltreleSarkiMetni(filtre);
            this.rptSonuclar.DataSource = sonuclar;
            this.rptSonuclar.DataBind();
        }

        protected void rptSonuclar_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (Session["UyeID"] != null)
            {
                var control = e.Item.FindControl("lnkFavorilerimeEkle");

                if (control != null)
                {
                    LinkButton lnkFavorilerimeEkle = (control as LinkButton);
                    lnkFavorilerimeEkle.Click += lnkFavorilerimeEkle_Click;
                    ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(lnkFavorilerimeEkle);
                }
            }
        }

        protected void lnkFavorilerimeEkle_Click(object sender, EventArgs e)
        {
            if (Session["UyeID"] != null)
            {
                LinkButton btn = sender as LinkButton;
                int sarkiId = int.Parse(btn.CommandArgument);
                int uyeId = int.Parse(Session["UyeID"].ToString());

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                bool sonuc = yardimci.FavorilereEkle(uyeId, sarkiId);

                if (sonuc)
                    this.FavorilerYukle();
            }
        }

        protected void rptFavoriler_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            var control = e.Item.FindControl("lnkFavoriSil");

            if (control != null)
            {
                LinkButton lnkFavoriSil = (control as LinkButton);
                lnkFavoriSil.Click += lnkFavoriSil_Click;
                ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(lnkFavoriSil);
            }
        }

        protected void lnkFavoriSil_Click(object sender, EventArgs e)
        {
            if (Session["UyeID"] != null)
            {
                LinkButton btn = sender as LinkButton;
                int favoriId = int.Parse(btn.CommandArgument);

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                bool sonuc = yardimci.FavoriSil(favoriId);

                if (sonuc)
                    this.FavorilerYukle();
            }
        }
    }
}