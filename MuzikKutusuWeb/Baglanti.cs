using System.Data.OleDb;
using System.Web;

namespace MuzikKutusuWeb
{
    public class Baglanti
    {
        public static OleDbConnection BaglantiOlustur()
        {
            string veritabaniKonum = HttpContext.Current.Server.MapPath("~/App_Data/MuzikKutusuVeriTabani.accdb");
            return new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + veritabaniKonum + ";Persist Security Info=False;");
        }

        public static OleDbCommand Sorgulayici(OleDbConnection baglanti, string sorgu)
        {
            OleDbCommand sorgulayici = baglanti.CreateCommand();
            sorgulayici.CommandText = sorgu;

            return sorgulayici;
        }
    }
}