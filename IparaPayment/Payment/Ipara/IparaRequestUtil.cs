using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace IparaPayment.Payment.Ipara
{
    class IparaRequestUtil
    {
        /// <summary>
        ///     IparaAuth sınıfını xml formata dönüştürür
        /// </summary>
        /// <param name="auth"></param>
        /// <returns>xml format string</returns>
        public static string SerializeObject<T>(T auth)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                new XmlSerializer(typeof(T)).Serialize(ms, auth, ns);
                XmlTextWriter textWriter = new XmlTextWriter(ms, Encoding.UTF8);

                ms = (System.IO.MemoryStream)textWriter.BaseStream;

                return new UTF8Encoding().GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xml formatlı texti PaymetResponse sınıfına dönüştürür.
        /// </summary>
        /// <param name="pXmlizedString"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string pXmlizedString)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                return (T)Convert.ChangeType(xs.Deserialize(memoryStream), typeof(T));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        /// <summary>
        ///     Api ye xml data istek gönderilip cevap alınır.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="dateTime"></param>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static string ApiRequest(string token, string version, string dateTime, string xmlData, string url)
        {
            string xmlResponse = string.Empty;

            try
            {
                xmlData = xmlData.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"").Replace("\r\n", "");
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(xmlData);

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Headers.Add("transactionDate", dateTime);
                httpWebRequest.Headers.Add("version", version);
                httpWebRequest.Headers.Add("token", token);

                httpWebRequest.Method = WebRequestMethods.Http.Post;
                httpWebRequest.Accept = "application/xml";
                httpWebRequest.ContentType = "application/xml; charset=utf-8";
                httpWebRequest.ContentLength = buffer.Length;
                System.IO.Stream rs = httpWebRequest.GetRequestStream();
                rs.Write(buffer, 0, buffer.Length);
                rs.Close();
                var response = httpWebRequest.GetResponse();

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    xmlResponse = sr.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse err = ex.Response as HttpWebResponse;
                if (err != null)
                {
                    string htmlResponse = new StreamReader(err.GetResponseStream()).ReadToEnd();
                }

                xmlResponse = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return xmlResponse;
        }

        public static string GetSHA1(string SHA1Data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] hashbytes = System.Text.Encoding.UTF8.GetBytes(SHA1Data);
            byte[] inputbytes = sha.ComputeHash(hashbytes);
            return Convert.ToBase64String(inputbytes);
        }
    }
}