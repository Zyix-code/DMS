# 📦 DMS – Depo & Sipariş Yönetim Sistemi  
<p align="center">
  <img src="https://media.giphy.com/media/Y4ak9Ki2GZCbJxAnJD/giphy.gif" width="140px">
</p>

<p align="center">
  <b>.NET C# / WinForms üzerinde geliştirilmiş profesyonel depo & sipariş yönetim uygulaması.</b><br>
  Hızlı, güvenilir ve hatasız depo operasyonları için tasarlandı.
</p>

---

## 🚀 Özellikler

- ✔ **Sipariş Yönetimi:** Alıcı, firma, pazar yeri ve ürün bileşenleri ile detaylı kayıt  
- ✔ **Depo Giriş–Çıkış:** Ürün bazlı kontrol, hatalı/tekrarlı işleme engeli  
- ✔ **Gerçek Zamanlı Bildirim:** Sesli uyarı + Windows bildirim balonu  
- ✔ **E-posta Gönderimi:** Sipariş özeti, sistem bilgilendirmeleri  
- ✔ **Log Sistemi:** Tüm işlemler anlık olarak kayıt altında  
- ✔ **VersionChecker:** Zorunlu/opsiyonel güncelleme kontrolü  
- ✔ **CSV dışa aktarma + yedekleme**  
- ✔ **SQL Server tabanlı güçlü veri modeli**

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white&style=flat-square">
  <img src="https://img.shields.io/badge/.NET_Framework-512BD4?logo=dotnet&logoColor=white&style=flat-square">
  <img src="https://img.shields.io/badge/WinForms-512BD4?logo=windows&style=flat-square">
  <img src="https://img.shields.io/badge/MSSQL-CC2927?logo=microsoftsqlserver&logoColor=white&style=flat-square">
</p>

---

## 🧠 Sistem Nasıl Çalışır?

### 🔹 Sipariş Süreci  
- Aynı sipariş numarası tekrar oluşturulamaz.  
- Sipariş oluşturulduktan sonra işlemler **ürün hareketlerinden** ilerler.

### 🔹 Ürün Giriş/Çıkış Kuralları  
- Her ürün satırı bağımsız işlem olarak yönetilir.  
- Çift giriş veya çift çıkış engellenir.  
- Sadece giriş yapılan ürüne çıkış yapılabilir; tamamlanan ürün tekrar işlenemez.

### 🔹 Bildirim & Log  
- Yeni sipariş geldiğinde anlık bildirim  
- Tüm işlemler log sistemine otomatik işlenir  

### 🔹 Versiyon Kontrolü  
- Program açılışında SQL üzerinden sürüm kontrol edilir  
- Yeni sürüm varsa kullanıcı bilgilendirilir  
- Zorunlu güncelleme → program kapanır + web sitesi açılır

---

## 🛠️ Kurulum

### 1️⃣ Veritabanını Kurun  
Uygulama MSSQL üzerinde çalışır.  
`/Database` klasöründeki **DMS.sql** dosyasını çalıştırarak veritabanını oluşturun.

### 2️⃣ App.config Düzenleyin  

```xml
<connectionStrings>
    <add name="DMS" connectionString="Server=.;Database=DMS;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 3️⃣ Uygulamayı Çalıştırın  
Program açıldığında otomatik sürüm kontrolü yapılacaktır.

---

## 🤝 İletişim  
<p align="left">
  <a href="https://discordapp.com/users/481831692399673375"><img src="https://img.shields.io/badge/Discord-Zyix%231002-7289DA?logo=discord&style=flat-square"></a>
  <a href="https://www.youtube.com/channel/UC7uBi3y2HOCLde5MYWECynQ?view_as=subscriber"><img src="https://img.shields.io/badge/YouTube-Subscribe-red?logo=youtube&style=flat-square"></a>
  <a href="https://www.reddit.com/user/_Zyix"><img src="https://img.shields.io/badge/Reddit-Profile-orange?logo=reddit&style=flat-square"></a>
  <a href="https://open.spotify.com/user/07288iyoa19459y599jutdex6"><img src="https://img.shields.io/badge/Spotify-Follow-green?logo=spotify&style=flat-square"></a>
</p>

---
