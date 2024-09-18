using mbs.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Services.CryptoServices
{
    public class LinkServices
    {
        private readonly CryptoServices cryptoServices;

        public LinkServices(CryptoServices cryptoServices)
        {
            this.cryptoServices = cryptoServices;
        }
        public string GenerateLink(LinkData link)
        {
            var jsonData = JsonConvert.SerializeObject(link);
            var encryptedData = cryptoServices.Encrypt(jsonData);
            var urlEncodedData = WebUtility.UrlEncode(encryptedData);

            return $"http://localhost:5005/api/Customer/RedirectLink?EncryptedLink={urlEncodedData}";
        }
        public LinkData DecryptLink(string encryptedData)
        {
            try
            {
                var urlDecodedData = WebUtility.UrlDecode(encryptedData);
                var base64Data = urlDecodedData.Replace(' ', '+');

                var decryptedData = cryptoServices.Decrypt(base64Data);

                if (string.IsNullOrEmpty(decryptedData))
                {
                    throw new InvalidOperationException("Şifrelenmiş verinin içeriği boş.");
                }
                var linkData = JsonConvert.DeserializeObject<LinkData>(decryptedData);
                if (linkData == null)
                {
                    throw new InvalidOperationException("JSON verisi geçersiz.");
                }

                return linkData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw new InvalidOperationException("Bilinmeyen bir hata oluştu.", ex);
            }
        }

        //public string RedirectLink(string encryptedData)
        //{
        //    try
        //    {
        //        var urlDecodedData = WebUtility.UrlDecode(encryptedData);
        //        var base64Data = urlDecodedData.Replace(' ', '+');

        //        var decryptedData = cryptoServices.Decrypt(base64Data);

        //        if (string.IsNullOrEmpty(decryptedData))
        //        {
        //            throw new InvalidOperationException("Şifrelenmiş verinin içeriği boş.");
        //        }
        //        var linkData = JsonConvert.DeserializeObject<LinkData>(decryptedData);
        //        if (linkData == null)
        //        {
        //            throw new InvalidOperationException("JSON verisi geçersiz.");
        //        }
        //        if (linkData.Expiry < DateTime.Now)
        //        {
        //            throw new Exception("Link has timed out");
        //        }
        //        var endpoint = linkData.Endpoint;
        //        var templateId = linkData.TemplateId;
        //        var customerId = linkData.CustomerId;
        //        var redirectUrl = $"http://localhost:5005/{endpoint}/{customerId}/{templateId}";

        //        return redirectUrl;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Exception: {ex.Message}");
        //        throw new InvalidOperationException(ex.ToString());
        //    }
        //}
    }
}
