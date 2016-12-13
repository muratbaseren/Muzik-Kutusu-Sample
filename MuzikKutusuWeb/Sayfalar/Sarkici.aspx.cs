using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TweetSharp;

namespace MuzikKutusuWeb.Sayfalar
{
    public partial class Sarkici : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                int sarkiciId = int.Parse(Request.QueryString["ID"]);

                VeritabaniYardimci yardimci = new VeritabaniYardimci();
                DataTable sarkici = yardimci.SarkiciGetir(sarkiciId);

                if (sarkici.Rows.Count > 0)
                {
                    string sarkiciScreenName = sarkici.Rows[0]["SarkiciTwitter"].ToString();
                    string sarkiciAd = sarkici.Rows[0]["SarkiciAd"].ToString();

                    this.lblBaslik.Text = sarkiciAd + " Paylaştığı Tweet'ler:";
                    this.lnkSarkiciTwitter.Text = "@" + sarkiciScreenName;
                    this.lnkSarkiciTwitter.NavigateUrl = "https://twitter.com/" + sarkiciScreenName;

                    Session["SarkiciScreenName"] = sarkiciScreenName;
                }
            }
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            if (Session["SarkiciScreenName"] != null)
            {
                string screenName = Session["SarkiciScreenName"].ToString();

                var service = new TwitterService("Yrq7nWkcJZWafl8AlCJ7tw", "X0tWjFeXpA9XfCwbCCh9lGlFVN7BXsCQ8CYqWNfG6A");
                service.AuthenticateWith("1521854989-WOniLBLwCey8ixJa0XEsOBLMJLd372UZjZ0g1qY", "4XYQJxuiQtTYUC5DtF5myEX4GH9QPYSdp4zO5DfrE");

                var opt = new TweetSharp.ListTweetsOnUserTimelineOptions();
                opt.ScreenName = screenName;

                IEnumerable<TwitterStatus> tweets = service.ListTweetsOnUserTimeline(opt);

                this.rptTwitter.DataSource =
                    (from x in tweets.ToList()
                     select new { tweet = x.Text }).ToList();

                this.rptTwitter.DataBind();
            }
        }
    }
}