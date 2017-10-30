using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IparaPayment.Payment.Ipara
{
    /// <summary>
    /// Entegrasyon ayrintilari icin luften entegrasyon dokumanlarini inceleyiniz.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Lutfen size iletilmis olan magazaniza ait Public Key - Acik Anahtar bilgisini bu parametrede yaziniz.
        /// </summary>
        public static readonly string PublicKey = "";
        /// <summary>
        /// Lutfen size iletilmis olan magazaniza ait Private Key - Gizli Anahtar bilgisini bu parametrede yaziniz.
        /// </summary>
        public static readonly string PrivateKey = "";
        /// <summary>
        ///  Modun "T" olmasi odemenin bir test odemesi oldugunu belirtir.
        /// </summary>
        public static readonly string Mode = "T";
        /// <summary>
        /// Eger bir altyapi saglayiciniz yok ise, bu alani bos ya da null birakiniz.
        /// Eger altyapi saglayici ile calisiyorsaniz, o halde vendor id bilgisini bu parametrede yaziniz.
        /// </summary>
        public static readonly string VendorId = null;
        /// <summary>
        /// Ipara'ya ait canli sistem baz API URL adresidir.
        /// </summary>
        public static readonly string BaseIparaAPIUrl = "https://api.ipara.com";
        /// <summary>
        /// Ipara'ya ait canli sistem servlet'lerin baz URL adresidir.
        /// </summary>
        public static readonly string BaseIparaThreeDUrl = "https://www.ipara.com";
        /// <summary>
        /// Kullanilmakta olan API versiyonunu belirtir. API versiyonu ayrintilari icin teknik entegrasyon dokumanlarini inceleyiniz.
        /// </summary>
        public static readonly string Version = "1.0";
    }
}
