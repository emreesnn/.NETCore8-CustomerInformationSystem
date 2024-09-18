# Müşteri Sipariş Yönetim Sistemi

Bu proje, .NET Core'da pratik kazanabilmek amacıyla oluşturulmuştur ve Clean Architecture ile Onion Architecture prensiplerini takip eder. Proje, modern teknolojiler ve tasarım desenleri kullanılarak ölçeklenebilirlik, sürdürülebilirlik ve güvenlik hedeflenmiştir.

## Özellikler

- **Clean Architecture (Onion Architecture)**: Katmanlı mimari ile sorumlulukları ayırır ve bakım kolaylığı sağlar.
- **MediatR**: İstek ve yanıtları verimli bir şekilde işlemek için CQRS (Komut-Sorgu Sorumluluk Ayrımı) desenini uygular.
- **AutoMapper**: Nesneler arası veri dönüştürmeyi kolaylaştırarak manuel dönüşüm ihtiyacını ortadan kaldırır.
- **JWT Kimlik Doğrulama**: JSON Web Token'ları kullanarak güvenli kimlik doğrulama sağlar ve rol bazlı yetkilendirme içerir.
- **Dapper**: Yüksek performanslı veri erişimi için ham SQL sorgularını yürütür.
- **FluentValidation**: İstek modelleri için doğrulama kuralları ekleyerek veri bütünlüğünü sağlar.
- **Özel Hata Yönetimi**: Merkezi bir hata yönetim mekanizması uygular, hataların şeffaflığını ve kontrolünü artırır.
- **Genel Depo (Repository) Deseni**: Veri erişim mantığını basitleştirir ve esneklik sağlar.
- **Kriptografi**: Müşteri bilgilerini içeren bağlantıları güvenli bir şekilde şifreler.

## Kullanım Senaryosu

Bu proje, firmaların belirli verileri müşterileriyle güvenli bir şekilde paylaşmasını sağlar. İş akışı şu şekildedir:

1. Firma yöneticileri sisteme giriş yaparak bir özel SQL sorgusu oluşturur (örn. `son_siparişler`), bu sorgu müşterinin en son sipariş geçmişini getirir.
2. Sistem, sorguyu veritabanına kaydeder ve her müşteri için güvenli, şifrelenmiş bir bağlantı oluşturur.
3. Müşteriler bu bağlantıyı alarak, tıklayarak en son siparişlerini görüntüleyebilirler.
4. Müşteriler, yalnızca verileri görüntüleme yetkisine sahiptir; bağlantı üzerinden veri değişikliği yapamazlar.

## Teknolojiler

- **.NET Core**: Backend framework.
- **MySQL**: Veritabanı motoru.
- **MediatR, AutoMapper, JWT**: İstek işleme, nesne eşleme ve kimlik doğrulama için temel kütüphaneler.
- **Dapper**: Ham SQL sorgularını yürütmek için kullanılır.
- **FluentValidation**: Model doğrulama için kullanılır.
- **Kriptografi**: Bağlantılar üzerinden paylaşılan verileri güvenli bir şekilde şifrelemek için kullanılır.
