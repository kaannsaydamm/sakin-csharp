# sakin-csharp

## DİKKAT, DAHA DENEYSEL BİR AŞAMADA, AMATÖRCE YAZILMIŞ OLUP, AMATÖRCE GELİŞTİRİLMEKTEDİR. BU BİR SELF_DEVELOPMENT PROJESİDİR. <h1>BU DİZİDEKİLER TAMAMEN BİR HAYAL ÜRÜNÜDÜR, GERÇEK KİŞİLER VEYAHUT KURUMLAR İLE ALAKASI YOKTUR. :D </h1>

Sakin CSharp, sistem olaylarını toplamak ve yönetmek için geliştirilmiş bir .NET Core uygulamasıdır. Bu proje, hem Windows hem de Linux sistemlerinde çalışabilen bir olay günlüğü toplama mekanizması sunar. Kullanıcıların sistem olaylarını izlemelerine ve bu olayları veritabanında saklamalarına olanak tanır.

## Özellikler

- **Çoklu Platform Desteği**: Hem Windows hem de Linux sistemlerinde çalışabilir.
- **Olay Günlüğü Toplama**: Sistem olaylarını toplayarak kullanıcıya raporlar sunar.
- **Veritabanı Entegrasyonu**: Toplanan olaylar, SQL Server veritabanında saklanır.
- **Kullanıcı Dostu Arayüz**: Basit ve anlaşılır bir kullanıcı arayüzü ile kullanıcı deneyimini artırır.
- **Güvenlik**: Uygulama, sistem olaylarının güvenli bir şekilde toplanmasını ve saklanmasını sağlar.

## Gereksinimler

- .NET Core 3.1 veya üzeri
- SQL Server (veya başka bir veritabanı yönetim sistemi)
- Gerekli NuGet paketleri (SharpPcap, PacketDotNet)
- İnternet bağlantısı

## Kurulum

1. **Proje Klonlama**:
   ```bash
   git clone https://github.com/kullaniciadi/sakin-csharp.git
   cd sakin-csharp
   ```
2. **NuGet Paketlerinin Yüklenmesi**:
   ```bash
   dotnet restore
   ```
3. **Uygulamanın Çalıştırılması**:
   ```bash
   dotnet run
   ```
