using System.Data;
using System.Data.OleDb;
using System.Web;

namespace MuzikKutusuWeb
{
    public class VeritabaniYardimci
    {

        /**********************************************************************************************************************/
        // Sisteme Giriş için..
        /**********************************************************************************************************************/

        public bool UyeGiris(string eposta, string sifre)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM Uyeler WHERE EPosta = ? AND Sifre = ?");
            komutlayici.Parameters.AddWithValue("?", eposta);
            komutlayici.Parameters.AddWithValue("?", sifre);

            baglanti.Open();
            OleDbDataReader okuyucu = komutlayici.ExecuteReader();

            while (okuyucu.Read())
            {
                int id = okuyucu.GetInt32(0);
                string ad = okuyucu.GetString(1);
                string soyad = okuyucu.GetString(2);
                string epostaAdr = okuyucu.GetString(3);
                string uyelik = okuyucu.GetString(5);

                HttpContext.Current.Session["UyeID"] = id;
                HttpContext.Current.Session["UyeAd"] = ad;
                HttpContext.Current.Session["UyeSoyad"] = soyad;
                HttpContext.Current.Session["UyeEPosta"] = epostaAdr;
                HttpContext.Current.Session["UyeUyelik"] = uyelik;

                sonuc = true;
                break;
            }

            baglanti.Close();

            return sonuc;
        }

        public bool YoneticiGiris(string eposta, string sifre)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM Uyeler WHERE EPosta = ? AND Sifre = ? AND UyelikTuru='yönetici'");
            komutlayici.Parameters.AddWithValue("?", eposta);
            komutlayici.Parameters.AddWithValue("?", sifre);

            baglanti.Open();
            OleDbDataReader okuyucu = komutlayici.ExecuteReader();

            while (okuyucu.Read())
            {
                int id = okuyucu.GetInt32(0);
                string ad = okuyucu.GetString(1);
                string soyad = okuyucu.GetString(2);
                string epostaAdr = okuyucu.GetString(3);
                string uyelik = okuyucu.GetString(5);

                HttpContext.Current.Session["UyeID"] = id;
                HttpContext.Current.Session["UyeAd"] = ad;
                HttpContext.Current.Session["UyeSoyad"] = soyad;
                HttpContext.Current.Session["UyeEPosta"] = epostaAdr;
                HttpContext.Current.Session["UyeUyelik"] = uyelik;

                sonuc = true;
                break;
            }

            baglanti.Close();

            return sonuc;
        }


        /**********************************************************************************************************************/
        // Üyeler için..
        /**********************************************************************************************************************/

        public bool UyeKayit(string eposta, string sifre)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "INSERT INTO Uyeler ( Ad, Soyad, EPosta, Sifre, UyelikTuru ) VALUES (?,?,?,?,?)");
            komutlayici.Parameters.AddWithValue("?", "adınız");
            komutlayici.Parameters.AddWithValue("?", "soyadınız");
            komutlayici.Parameters.AddWithValue("?", eposta);
            komutlayici.Parameters.AddWithValue("?", sifre);
            komutlayici.Parameters.AddWithValue("?", "üye");

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
                sonuc = true;

            baglanti.Close();

            return sonuc;
        }

        public bool UyeDuzenle(string ad, string soyad, string eposta, string sifre, string uyelikTuru, int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "UPDATE Uyeler SET Ad=?,Soyad=?,EPosta=?,Sifre=?,UyelikTuru=? WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", ad);
            komutlayici.Parameters.AddWithValue("?", soyad);
            komutlayici.Parameters.AddWithValue("?", eposta);
            komutlayici.Parameters.AddWithValue("?", sifre);
            komutlayici.Parameters.AddWithValue("?", uyelikTuru);
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }

        public bool UyeSil(int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "DELETE FROM Uyeler  WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }

        public DataTable UyeListesiGetir()
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM Uyeler");
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public DataTable UyeGetir(int id)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM Uyeler WHERE ID=?");

            komutlayici.Parameters.AddWithValue("?", id);

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }


        /**********************************************************************************************************************/
        // Müzik Türleri için..
        /**********************************************************************************************************************/

        public bool MuzikTuruEkle(string muzikTuru)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "INSERT INTO MuzikTurleri ( TurAd ) VALUES (?)");
            komutlayici.Parameters.AddWithValue("?", muzikTuru);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
                sonuc = true;

            baglanti.Close();

            return sonuc;
        }

        public bool MuzikTuruDuzenle(string muzikTuru, int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "UPDATE MuzikTurleri SET TurAd=? WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", muzikTuru);
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }

        public bool MuzikTuruSil(int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "DELETE FROM MuzikTurleri WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;

                this.SarkiSilMuzikTuruneAit(id);
            }

            baglanti.Close();

            return sonuc;
        }

        public DataTable MuzikTurleriGetir()
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM MuzikTurleri");
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public DataTable MuzikTuruGetir(int id)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM MuzikTurleri WHERE ID=?");

            komutlayici.Parameters.AddWithValue("?", id);

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }


        /**********************************************************************************************************************/
        // Şarkıcılar için..
        /**********************************************************************************************************************/

        public DataTable SarkicilarGetir()
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM Sarkicilar");
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public bool SarkiciSil(int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "DELETE FROM Sarkicilar WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;

                this.SarkiSilSarkiciyaAit(id);
            }

            baglanti.Close();

            return sonuc;
        }

        public bool SarkiciEkle(string ad, string twitter)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "INSERT INTO Sarkicilar ( SarkiciAd, SarkiciTwitter ) VALUES (?,?)");
            komutlayici.Parameters.AddWithValue("?", ad);
            komutlayici.Parameters.AddWithValue("?", twitter);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
                sonuc = true;

            baglanti.Close();

            return sonuc;
        }

        public DataTable SarkiciGetir(int id)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM Sarkicilar WHERE ID=?");

            komutlayici.Parameters.AddWithValue("?", id);

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public bool SarkiciDuzenle(string ad, string twitter, int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "UPDATE Sarkicilar SET SarkiciAd=?, SarkiciTwitter=? WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", ad);
            komutlayici.Parameters.AddWithValue("?", twitter);
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }


        /**********************************************************************************************************************/
        // Şarkılar için..
        /**********************************************************************************************************************/

        public DataTable SarkilarGetir()
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM SarkilarWithSarkicilarWithMuzikTurleri");
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public bool SarkiEkle(string ad, int sarkiciId, int muzikTuruId)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "INSERT INTO Sarkilar ( SarkiciId, MuzikTuruId, SarkiAd ) VALUES (?,?,?)");
            komutlayici.Parameters.AddWithValue("?", sarkiciId);
            komutlayici.Parameters.AddWithValue("?", muzikTuruId);
            komutlayici.Parameters.AddWithValue("?", ad);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
                sonuc = true;

            baglanti.Close();

            return sonuc;
        }

        public bool SarkiSil(int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "DELETE FROM Sarkilar WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }

        public DataTable SarkiGetir(int id)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM Sarkilar WHERE ID=?");

            komutlayici.Parameters.AddWithValue("?", id);

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public bool SarkiDuzenle(string ad, int sarkiciId, int muzikTuruId, int id)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "UPDATE Sarkilar SET SarkiAd=?, SarkiciID=?, MuzikTuruID=? WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", ad);
            komutlayici.Parameters.AddWithValue("?", sarkiciId);
            komutlayici.Parameters.AddWithValue("?", muzikTuruId);
            komutlayici.Parameters.AddWithValue("?", id);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }

        private bool SarkiSilMuzikTuruneAit(int muzikTuruId)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "DELETE FROM Sarkilar WHERE MuzikTuruID=?");
            komutlayici.Parameters.AddWithValue("?", muzikTuruId);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }

        private bool SarkiSilSarkiciyaAit(int sarkiciId)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "DELETE FROM Sarkilar WHERE SarkiciID=?");
            komutlayici.Parameters.AddWithValue("?", sarkiciId);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }


        /**********************************************************************************************************************/
        // Filtreleme için..
        /**********************************************************************************************************************/

        public DataTable FiltreleSarkiciyaGore(int sarkiciId)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM SarkilarWithSarkicilarWithMuzikTurleri WHERE SarkiciID=?");

            komutlayici.Parameters.AddWithValue("?", sarkiciId);

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public DataTable FiltreleMuzikTuruneGore(int muzikTuruId)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM SarkilarWithSarkicilarWithMuzikTurleri WHERE MuzikTuruID=?");

            komutlayici.Parameters.AddWithValue("?", muzikTuruId);

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public DataTable FiltreleSarkiMetni(string filtre)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM SarkilarWithSarkicilarWithMuzikTurleri");

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            if(tablo.Rows.Count > 0)
                tablo = tablo.Select("SarkiAd LIKE '%" + filtre + "%'").CopyToDataTable();

            return tablo;
        }


        /**********************************************************************************************************************/
        // Favoriler için..
        /**********************************************************************************************************************/

        public DataTable FavorilerGetir(int uyeId)
        {
            DataTable tablo = new DataTable();
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();
            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "SELECT * FROM SarkilarWithSarkicilarWithMuzikTurleriKullanici WHERE UyeID=?");

            komutlayici.Parameters.AddWithValue("?", uyeId);

            OleDbDataAdapter adaptor = new OleDbDataAdapter(komutlayici);

            adaptor.Fill(tablo);

            return tablo;
        }

        public bool FavorilereEkle(int uyeId, int sarkiId)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "INSERT INTO Favoriler ( UyeID, SarkiID) VALUES (?,?)");
            komutlayici.Parameters.AddWithValue("?", uyeId);
            komutlayici.Parameters.AddWithValue("?", sarkiId);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
                sonuc = true;

            baglanti.Close();

            return sonuc;
        }

        public bool FavoriSil(int favoriId)
        {
            bool sonuc = false;
            OleDbConnection baglanti = Baglanti.BaglantiOlustur();

            OleDbCommand komutlayici = Baglanti.Sorgulayici(baglanti, "DELETE FROM Favoriler WHERE ID=?");
            komutlayici.Parameters.AddWithValue("?", favoriId);

            baglanti.Open();
            int etkilenenKayitSayisi = komutlayici.ExecuteNonQuery();

            if (etkilenenKayitSayisi > 0)
            {
                sonuc = true;
            }

            baglanti.Close();

            return sonuc;
        }
    }
}