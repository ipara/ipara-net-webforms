using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string PublicKey { get { return "WY48CP014UFLQ4A"; } }           //"Public Magaza Anahtarı - size mağaza başvurunuz sonucunda gönderilen public key (açık anahtar) bilgisini kullanınız.",
        public string PrivateKey { get { return "WY48CP014UFLQ4A0VSW12US00"; } }          //"Private Magaza Anahtarı  - size mağaza başvurunuz sonucunda gönderilen privaye key (gizli anahtar) bilgisini kullanınız.",
        public string BaseUrl { get { return "https://api.ipara.com/";  } }             //iPara web servisleri API url'lerinin başlangıç bilgisidir.
        public string ThreeDInquiryUrl { get { return "https://www.ipara.com/3dgate"; } }    //iPara 3D operasyonu için güvenlik sorgusu servisinin URL bilgisi.
        public string Mode { get { return "T"; } }                // Test -> T, entegrasyon testlerinin sırasında "T" modunu, canlı sisteme entegre olarak ödeme almaya başlamak için ise Prod -> "P" modunu kullanınız.
        public string Version { get { return "1.0";  } }             // Kullandığınız iPara API versiyonudur. 
        public string HashString { get; set; }          // Kullanacağınız hash bilgisini, bağlanmak istediğiniz web servis bilgisine göre doldurulmalıdır.
        public string TransactionDate { get; set; }     //IPara.DeveloperPortal.Core.Helper#GetTransactionDateString() ile transaction'in gerçekleştiği zaman bilgisini iletmekte kullanılır.
    }
}
