using DotNetCode.Spid.SAML;
using DotNetCode.Spid.OpenId;
using DotNetCode.Spid.Oauth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DotNetCode.Spid.Helpers
{
    public static class ServiceProviderHelper
    {


        /// <summary>
        /// Gets the service provider from URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<ServiceProvider> GetFromUrlAsync(string url)
        {
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync(url);
            if (string.IsNullOrWhiteSpace(json)) { throw new FileNotFoundException(url); }

            return JsonConvert.DeserializeObject<ServiceProvider>(json);

        }


        /// <summary>
        /// Gets the service provider from file asynchronous.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<ServiceProvider> GetFromFileAsync(string filePath)
        {
            string json = string.Empty;
            if (File.Exists(filePath))
            {
                using (var reader = File.OpenText(filePath))
                {
                    json = await reader.ReadToEndAsync();
                }
            }
            if (string.IsNullOrWhiteSpace(json)) { throw new FileNotFoundException(filePath); }

            return JsonConvert.DeserializeObject<ServiceProvider>(json);

        }



    }
}
