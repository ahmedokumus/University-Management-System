# Web Tasarım Projesi

Bu proje, danışmanlık yaptığım bir öğrenci için dönem sonu projesi olarak hazırlanmıştır. Proje, bir üniversitede Yönetici, Memur, Öğretim Elemanı ve Öğrenciler için tasarlanmış bir yönetim sistemidir.

## Proje Hakkında

Bu proje, ASP.NET MVC framework'ü kullanılarak geliştirilmiş bir web uygulamasıdır. Modern web teknolojileri ve best practice'ler göz önünde bulundurularak tasarlanmıştır.

## Kullanıcı Rolleri ve Görevleri

### Yönetici (Admin) Görevleri
- Fakülte listesini görüntüleme ve yeni fakülte ekleme
- Bölüm listesini görüntüleme ve yeni bölüm ekleme
- Ders listesini görüntüleme ve yeni ders ekleme
- Öğretim elemanı listesini görüntüleme ve yeni öğretim elemanı ekleme
- Öğrenci listesini görüntüleme
- Sistem istatistiklerini görüntüleme (fakülte, bölüm, ders ve öğretim elemanı sayıları)

### Memur (Officer) Görevleri
- Ders listesini görüntüleme ve derslere öğretim elemanı atama
- Öğrenci listesini görüntüleme ve yönetme
- Yeni öğrenci kaydı oluşturma
- Öğrenci bilgilerini güncelleme (profil fotoğrafı dahil)
- Öğrenci bölüm bilgilerini güncelleme

### Öğretim Elemanı (Instructor) Görevleri
- Kendisine atanan dersleri görüntüleme
- Derslerindeki öğrenci listesini görüntüleme
- Öğrencilerin vize ve final notlarını girme/düzenleme

### Öğrenci (Student) Görevleri
- Bölümündeki mevcut dersleri görüntüleme
- Ders kaydı yapma
- Sınav sonuçlarını (vize ve final) görüntüleme

## Teknolojiler

- ASP.NET MVC
- C#
- Entity Framework
- HTML5
- CSS3
- JavaScript
- Bootstrap

## Proje Yapısı

Proje aşağıdaki ana bileşenlerden oluşmaktadır:

- `Controllers/`: MVC mimarisinin controller katmanı
- `Models/`: Veri modelleri ve veritabanı işlemleri
- `Views/`: Kullanıcı arayüzü şablonları
- `Content/`: CSS dosyaları ve statik içerikler
- `Scripts/`: JavaScript dosyaları
- `App_Data/`: Uygulama verileri
- `Security/`: Güvenlik ile ilgili işlemler

## Kurulum

1. Projeyi klonlayın
2. Visual Studio ile .sln dosyasını açın
3. NuGet paketlerini restore edin
4. Projeyi derleyin ve çalıştırın

## Gereksinimler

- Visual Studio 2019 veya üzeri
- .NET Framework 4.7.2 veya üzeri
- SQL Server (LocalDB) 