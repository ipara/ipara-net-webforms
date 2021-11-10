using System;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace IparaPayment
{
    /// <summary>
    /// JSON ve XML'leri verilen adreslere post eden sınıftır. Verilen Response sınıfına göre geri dönüş yapar, 
    /// aynen kopyalanarak kullanılabilir
    /// </summary>
    public class RestHttpCaller
    {
        public static RestHttpCaller Create()
        {
            return new RestHttpCaller();
        }

        public T GetJson<T>(String url)
        {
            HttpClient httpClient = new();
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;

            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Alanların Json olarak post edilmesine olanak sağlar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public T PostJson<T>(String url, WebHeaderCollection headers, BaseRequest request)
        {
            HttpClient httpClient = new();
            foreach (String key in headers.Keys)
            {
                httpClient.DefaultRequestHeaders.Add(key, headers.Get(key));
            }
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, JsonBuilder.ToJsonString(request)).Result;
            var a = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(a);
        }

        public T GetXML<T>(String url)
        {
            HttpClient httpClient = new();
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;

            return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Xml olarak post edilmesi istenen istek sınıflarında gönderilen değerlerin xml olarak post edilmesine
        /// imkan sağlayan metodu temsil eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public T PostXML<T>(String url, WebHeaderCollection headers, BaseRequest request)
        {
            HttpClient httpClient = new();
            foreach (String key in headers.Keys)
            {
                httpClient.DefaultRequestHeaders.Add(key, headers.Get(key));
            }
            var xml = XmlBuilder.SerializeToXMLString(request);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, xml).Result;
            var a = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return XmlBuilder.DeserializeObject<T>(a);
        }

    }
}
