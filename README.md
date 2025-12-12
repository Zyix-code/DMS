📘 DMS – Depo & Sipariş Yönetim Sistemi
<p align="center"> <img src="https://media.giphy.com/media/Y4ak9Ki2GZCbJxAnJD/giphy.gif" width="150px"><br> </p> <p align="center"> <samp> Merhaba, ben Selçuk! 👋<br> Bu proje, depo ve sipariş süreçlerini daha hızlı, hatasız ve verimli yönetmek için geliştirilmiş profesyonel bir Windows masaüstü uygulamasıdır. <br> (.NET – C# WinForms) </samp> </p> <p align="center"> <a href="https://discordapp.com/users/481831692399673375"> <img src="https://img.shields.io/badge/Discord-Zyix%231002-7289DA?logo=discord&style=flat-square" alt="Discord"> </a> <a href="https://www.youtube.com/channel/UC7uBi3y2HOCLde5MYWECynQ?view_as=subscriber"> <img src="https://img.shields.io/badge/YouTube-Subscribe-red?logo=youtube&style=flat-square" alt="YouTube"> </a> <a href="https://www.reddit.com/user/_Zyix"> <img src="https://img.shields.io/badge/Reddit-Profile-orange?logo=reddit&style=flat-square" alt="Reddit"> </a> <a href="https://open.spotify.com/user/07288iyoa19459y599jutdex6"> <img src="https://img.shields.io/badge/Spotify-Follow-green?logo=spotify&style=flat-square" alt="Spotify"> </a> </p>
🏭 DMS Nedir?

DMS (Depo Management System), depo operasyonlarını dijitalleştirmek ve kolaylaştırmak amacıyla geliştirilmiş güçlü bir masaüstü uygulamasıdır.
Kullanıcılar sipariş oluşturabilir, takibini yapabilir, ürün girişi/çıkışı yapabilir ve tüm hareketleri detaylı şekilde raporlayabilir.

⚙️ Öne Çıkan Özellikler

✔ Sipariş kaydı: Alıcı, firma, pazar yeri ve ürün bileşenlerini içeren detaylı sipariş yönetimi
✔ Depo giriş/çıkış takibi
✔ Ürün bazlı bağımsız giriş/çıkış kontrolü
✔ Hatalı veya tekrar giriş/çıkış önlemesi
✔ Sipariş – ürün hareketleri ilişkili yapısı
✔ Log sistemi ile tüm işlemleri kayıt altına alma
✔ E-posta bildirimi (EmailHelper ile)
✔ Gerçek zamanlı bildirim (SoundHelper ile sesli uyarı + notify balloon)
✔ SQL Server üzerinde çalışan güçlü database modeli
✔ Yedekleme & CSV Dışa Aktarma
✔ Versiyon kontrol sistemi (VersionChecker)
✔ Zorunlu / opsiyonel güncelleme yönetimi
✔ Güncelleme olduğunda web siteye yönlendirme

🧠 DMS Projesi Nasıl Çalışır?
🔹 Sipariş Yönetimi

Aynı sipariş numarası ile farklı alıcı / firma / pazar yeri girilmesi engellenir.

Sipariş bir kere oluşturulmuşsa tekrar eklenmez, ürün hareketi üzerinden ilerlenir.

🔹 Ürün Giriş–Çıkış Kontrolü

Her ürün satırı için ayrı giriş/çıkış kaydı tutulur.

Bir ürün için çift giriş veya çift çıkış engellenir.

Daha önce sadece “giriş” yapılmış ürün için “çıkış” yapılabilir.

Hem giriş hem çıkış tamamlanmış bir ürün tekrar işlenemez.

🔹 Otomatik Bildirimler

Yeni sipariş → tüm bağlı kullanıcılara anlık bildirim

E-posta ile sipariş özeti gönderimi

Log sistemi tüm işlemleri arka planda kaydeder

🔹 VersionChecker – Güncelleme Sistemi

Program açılışında otomatik olarak veritabanındaki en güncel versiyonu kontrol eder:

Versiyon küçük → güncelleme gerekli değil

Versiyon büyük → kullanıcıya bildirim

Zorunlu güncelleme → program kapanır, web sitesi açılır

Sürüm bilgileri SQL tablosundan alınır

🖼️ Ekran Görüntüleri (isteğe bağlı ekleyebilirim)

✔ Giriş ekranı
✔ Sipariş kayıt ekranı
✔ Ürün bileşenleri yönetimi
✔ Log ekranı
✔ Versiyon kontrol popup'ı
✔ Bildirim sistemi

Ekran görüntülerini göndermek istersen README’ye gallery şeklinde ekleyebilirim.

🛠️ Teknolojiler ve Araçlar
<p align="center"> <img src="https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white&style=flat-square"> <img src="https://img.shields.io/badge/.NET_Framework-512BD4?logo=dotnet&logoColor=white&style=flat-square"> <img src="https://img.shields.io/badge/WinForms-512BD4?logo=windows&style=flat-square"> <img src="https://img.shields.io/badge/MSSQL-CC2927?logo=microsoftsqlserver&logoColor=white&style=flat-square"> <img src="https://img.shields.io/badge/SMTP-Mail-orange?style=flat-square"> </p>
