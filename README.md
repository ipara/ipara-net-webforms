iPara .Net Web Forms Kütüphanesi
===================

iPara .Net Web Forms Kütüphanesidir. iPara API'lerine çok hızlı bir şekilde bağlanmanızı sağlar.
[https://www.ipara.com.tr](https://www.ipara.com.tr) adresimizden mağaza başvurusu yaparak
hesabınızı açabilirsiniz.

## Entegrasyon sürecinde dikkat edilecek noktalar

iPara servislerini kullanabilmek için iPara'ya üye olmalısınız. Üye olduktan sonra Mağaza Listesi > Detay sayfası içerisindeki Public ve Private Key sizinle paylaşılacaktır. Paylaşılan bu anahtarları ipara-web-forms projesinde Settings'de yer alan publicKey ve privateKey alanlarına eklemeniz gerekmektedir. İlgili örnek proje bir Class Library ve bir de .Net Web Forms Web projesi barındırır. Sonrasında örnek .Net Library'i kendi projenize referans ederek ilerleyebilirsiniz. Örnek datalardaki değişkenleri kendi projenizdeki gerçek verilerle set etmeyi unutmayınız.

```c#
namespace IparaPayment
{
    /// <summary>
    /// Tüm çağrılarda kullanılacak ayarların tutulduğu sınıftır. 
    /// Bu sınıf üzerinde size özel parametreler fonksiyonlar arasında taşınabilir.
    /// Bu sınıf üzerinde tüm sistemde kullanacağımız ayarları tutar ve bunlara göre işlem yaparız.
    /// Bu sınıf örnek projemizde BaseController içerisinde kullanılmıştır. Ve tüm ayarların kullanılacağı yerde karşımıza çıkmaktadır.
    /// </summary>
    public class Settings
    {
        public string PublicKey { get { return ""; } }           //"Public Magaza Anahtarı - size mağaza başvurunuz sonucunda gönderilen public key (açık anahtar) bilgisini kullanınız.",

        public string PrivateKey { get { return ""; } }          //"Private Magaza Anahtarı  - size mağaza başvurunuz sonucunda gönderilen privaye key (gizli anahtar) bilgisini kullanınız.",

        public string BaseUrl { get { return "https://api.ipara.com/"; } }             //iPara web servisleri API url'lerinin başlangıç bilgisidir.

        public string Mode { get { return "T"; } }                // Test -> T, entegrasyon testlerinin sırasında "T" modunu, canlı sisteme entegre olarak ödeme almaya başlamak için ise Prod -> "P" modunu kullanınız.

        public string Version { get { return "1.0"; } }             // Kullandığınız iPara API versiyonudur. 

        public string HashString { get; set; }          // Kullanacağınız hash bilgisini, bağlanmak istediğiniz web servis bilgisine göre doldurulmalıdır.

        public string TransactionDate { get; set; }     //IPara.DeveloperPortal.Core.Helper#GetTransactionDateString() ile transaction'in gerçekleştiği zaman bilgisini iletmekte kullanılır.
    }
}
```

Örnek projelerimizdeki servislerimizi daha iyi anlamak için [iPara geliştirici merkezini](http://dev.ipara.com.tr) takip etmeniz büyük önem arz etmektedir.

* Entegrasyon işlemlerinde encoding “UTF-8” kullanılması önerilmektedir.Token parametrelerinden kaynaklı sorun encoding probleminden kaynaklanmaktadır. Özel karakterlerde encoding işlemi yapılmalıdır.
* Servis isteği yaparaken göndermiş olduğunuz alanların başında ve sonunda oluşabilecek boşluk alanlarını kaldırmanızı ( trim() ) önemle rica ederiz. Çünkü bu alanlar oluşacak hash sonuçlarını etkilemektedir.
* Entegrasyon dahilinde gönderilen input alanlarında, kart numarası alanı dışında kart numarası bilgisi gönderilmesi halinde işlem reddedilecektir.

iPara örnek projelerinin amacı, yazılım geliştiricilere iPara servislerine entegre olabilecek bir proje örneği sunmak ve entegrasyon adımlarının daha iyi anlaşılmasını sağlamaktır.
Projeleri doğrudan canlı ortamınıza alarak kod değişimi yapmadan kullanmanız için desteğimiz bulunmamaktadır. **Projeyi bir eğitsel kaynak (tutorial) olarak kullanınız.**

## Test Kartları

Başarılı bir ödemeyi test etmek için aşağıdaki kart numaralarını ve diğer bilgileri kullanabilirsiniz.

| Sıra No  | Kart Numarası     | SKT    | CVC  | Banka                 | Kart Ailesi            |
|--------- |------------------ |------- |----- | ---------------       | ---------              |
| 1        | 4282209004348015  | 12/22  | 123  | Garanti Bankası       | BONUS                  |
| 2        | 5571135571135575  | 12/22  | 000  | Akbank                | AXESS                  |
| 3        | 4355084355084358  | 12/22  | 000  | Akbank                | AXESS                  |
| 4        | 4662803300111364  | 10/25  | 000  | Alternatif Bank       | BONUS                  |
| 5       | 4022774022774026  | 12/24  | 000  | Finansbank            | CARD FINANS            |
| 6        | 5456165456165454  | 12/24  | 000  | Finansbank            | CARD FINANS            |
| 7         | 9792023757123604  | 01/26     | 861   | Finansbank            | FINANSBANK DEBIT       |
| 8        | 4531444531442283  | 12/24  | 000  | Aktif Yatırım Bankası | AKTIF KREDI KARTI      |
| 9        | 5818775818772285  | 12/24  | 000  | Aktif Yatırım Bankası | AKTIF KREDI KARTI      |
| 10       | 4508034508034509  | 12/24  | 000  | İş bankası            | MAXIMUM                |
| 11       | 5406675406675403  | 12/24  | 000  | İş bankası            | MAXIMUM                |
| 12       | 4025903160410013  | 07/22  | 123  | Kuveyttürk            | KUVEYTTURK KREDI KARTI |
| 13       | 5345632006230604  | 12/24  | 310  | Aktif Yatırım Bankası | AKTIF KREDI KARTI      |
| 14       | 4282209027132016  | 12/24  | 358  | Garanti Bankası       | BONUS                  |
| 15       | 4029400154245816  | 03/24  | 373  | Vakıf Bank            | WORLD                  |
| 16       | 4029400184884303  | 01/23  | 378  | Vakıf Bank            | WORLD                  |
| 17       | 9792350046201275  | 07/27   | 993  | TÜRK ELEKTRONIK PARA  | PARAM KART             |
| 18       | 6501700194147183 | 03/27   | 136  | Vakıf Bank            | WORLD                  |
| 19      | 6500528865390837 | 01/22   | 686  | Vakıf Bank            | VAKIFBANK DEBIT        |

Test kartlarımızda alınan hata kodları ve çözümleriyle ilgili detaylı bilgiye ulaşabilmek için [iPara Hata Kodları](https://dev.ipara.com.tr/home/ErrorCode) inceleyebilirsiniz.

### Örnek Kullanım Yöntemi

```c#
    Settings settings = new();
    Non3DPaymentRequest request = new();
    request.OrderId = Guid.NewGuid().ToString();
    request.Echo = "Echo";
    request.Mode = settings.Mode;
    request.Amount = amount.Value;
    request.CardOwnerName = cardOwnerName.Value;
    request.CardNumber = cardNumber.Value;
    request.CardExpireMonth = cardExpireMonth.Value;
    request.CardExpireYear = cardExpireYear.Value;
    request.Installment = installment.Value;
    request.Cvc = cardCvc.Value;
    request.ThreeD = "false";
    request.CardId = "";
    request.UserId = "";

    request.Purchaser = new Purchaser();
    request.Purchaser.Name = "Murat";
    request.Purchaser.SurName = "Kaya";
    request.Purchaser.BirthDate = "1986-07-11";
    request.Purchaser.Email = "murat@kaya.com";
    request.Purchaser.GsmPhone = "5881231212";
    request.Purchaser.IdentityNumber = "12345678901";
    request.Purchaser.ClientIp = "127.0.0.1";

    request.Purchaser.InvoiceAddress = new PurchaserAddress();
    request.Purchaser.InvoiceAddress.Name = "Murat";
    request.Purchaser.InvoiceAddress.SurName = "Kaya";
    request.Purchaser.InvoiceAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
    request.Purchaser.InvoiceAddress.ZipCode = "34782";
    request.Purchaser.InvoiceAddress.CityCode = "34";
    request.Purchaser.InvoiceAddress.IdentityNumber = "1234567890";
    request.Purchaser.InvoiceAddress.CountryCode = "TR";
    request.Purchaser.InvoiceAddress.TaxNumber = "123456";
    request.Purchaser.InvoiceAddress.TaxOffice = "Kozyatağı";
    request.Purchaser.InvoiceAddress.CompanyName = "iPara";
    request.Purchaser.InvoiceAddress.PhoneNumber = "2122222222";

    request.Purchaser.ShippingAddress = new PurchaserAddress();
    request.Purchaser.ShippingAddress.Name = "Murat";
    request.Purchaser.ShippingAddress.SurName = "Kaya";
    request.Purchaser.ShippingAddress.Address = "Mevlüt Pehlivan Mah. Multinet Plaza Şişli";
    request.Purchaser.ShippingAddress.ZipCode = "34782";
    request.Purchaser.ShippingAddress.CityCode = "34";
    request.Purchaser.ShippingAddress.IdentityNumber = "1234567890";
    request.Purchaser.ShippingAddress.CountryCode = "TR";
    request.Purchaser.ShippingAddress.PhoneNumber = "2122222222";

    request.Products = new List<Product>();
    Product p = new();
    p.Title = "Telefon";
    p.Code = "TLF0001";
    p.Price = "5000"; //50.00 TL 
    p.Quantity = 1;
    request.Products.Add(p);

    p = new Product();
    p.Title = "Bilgisayar";
    p.Code = "BLG0001";
    p.Price = "5000"; //50.00 TL 
    p.Quantity = 1;
    request.Products.Add(p);

    Non3DPaymentResponse response = Non3DPaymentRequest.Execute(request, settings);
    string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
    result.InnerHtml = "<pre>" + jsonResponse + "</pre>";
```

## Hash Hesaplama

iPara servislerine entegre olurken alınan hataların en sık karşılaşılanı hash değerinin doğru hesaplanmasıdır. Hash değeri her servise göre değişen verilerin yanyana eklenmesi ile oluşan değerin bir dizi işleme tabi tutulması ile oluşur.

Aşağıdaki adreste hash hesaplama ile ilgili detaylar yer almaktadır. Yine burada yer alan interaktif fonksiyon ile hesapladığınız hash fonksiyonlarını test edebilirsiniz.

[iPara Hash Hesaplama](https://dev.ipara.com.tr/#hashCalculate)

Her örnek projenin Helper sınıfı içinde hash hesaplama ile alakalı bir fonksiyon bulunmaktadır. Entegrasyon sırasıdna bu hazır fonksiyonları da kullanabilirsiniz.

## Canlı Ortama Geçiş

* Test ortamında kullandığınız statik verilerin canlı ortamda gerçek müşteri datasıyla değiştirildiğinden emin olun.
Canlı ortamda yanlış, sabit data gönderilmediğinden emin olun. Gönderdiğiniz işlemlere ait verileri mutlaka size özel panelden görüntüleyin.
* Geliştirmeler tamamlandıktan sonra ödeme adımlarını, iPara test kartları ile tüm olası durumlar için test edin ve sonuçlarını görüntüleyin.
* iPara servislerinden dönen ve olabilecek tüm hataları karşılayacak ve müşteriye uygun cevabı gösterecek şekilde kodunuzu düzenleyin ve test edin. iPara hata kodları kullanıcı dostu mesajlar olup müşterinize gösterebilirsiniz.
* Hassas olmayan verileri ve servis yanıtlarını, hata çözümü ve olası sorunların çözümünde yardımcı olması açısından loglamaya dikkat edin.
* Canlı ortama geçiş sonrası ilk işlemleri kendi kredi kartlarınız ile deneyerek sonuçlarını size özel Kurum ekranlarından görüntüleyin. Sonuçların ve işlemlerin doğru tamamlandığından emin olun.

Sorularınız olması durumunda bize [Destek](http://dev.ipara.com.tr/Home/Support) üzerinden yazabilirsiniz.

## Versiyon Yenilikleri

| Versiyon | Versiyon Yenilikleri                                                                             |
|--------- |-------------------------------------------------------------------------------------------   |
| 1.0.1     | - İki adımlı ThreeD ödemesi kaldırılıp **Tek adımlı ThreeD** ödemesi eklendi.<br />- Ödeme sorgulama servisinde ek olarak **tarih filtresi** eklendi.<br />- **Link ile ödeme, ödeme linki sorgulama,ödeme linki silme** servisleri eklendi.<br />- **Ürün iade bilgisi sorgulama,ürün iade talebi** oluşturma servisleri eklendi. <br />- **Bin sorgulama servisine tutar bilgisi** eklenerek komisyon bilgisi kullanıcıya sunuldu. |
