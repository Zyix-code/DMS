using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS
{
    public static class UserSession
    {
        public static int KullaniciID { get; set; }
        public static string KullaniciAdi { get; set; }
        public static string Sifre {  get; set; }
        public static string AdSoyad { get; set; }
        public static string Eposta { get; set; }
        public static string Telefon { get; set; }
        public static string Departman { get; set; }
        public static int YetkiSeviyesi { get; set; }
        public static DateTime KayitTarihi { get; set; }
        public static bool Aktif { get; set; }
    }
   
    /* Kullanım
     * UserSession.KullaniciID = Convert.ToInt32(reader["ID"]);
    UserSession.KullaniciAdi = reader["KullaniciAdi"].ToString();
    UserSession.AdSoyad = reader["AdSoyad"].ToString();
    UserSession.Eposta = reader["Eposta"].ToString();
    UserSession.Telefon = reader["Telefon"].ToString();
    UserSession.Departman = reader["Departman"].ToString();
    UserSession.YetkiSeviyesi = Convert.ToInt32(reader["YetkiSeviyesi"]);
    UserSession.KayitTarihi = Convert.ToDateTime(reader["KayitTarihi"]);
    UserSession.Aktif = Convert.ToBoolean(reader["Aktif"]);*/

}
