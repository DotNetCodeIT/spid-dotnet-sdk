using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using DotNetCode.Spid;
using DotNetCode.Spid.Helpers;

namespace DotNetCode.Spid.Test
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void LoadServiceProvider()
        {
            string filePath = @"C:\SourceCode\spid-dotnet-sdk\test\Developers.Italia.SPID.Test\SpidServiceProviderConfig.json";

            ServiceProvider serviceProvider = JsonConvert.DeserializeObject<ServiceProvider>(File.ReadAllText(filePath));


        }

        [TestMethod]
        public void GetCertifcateFromStore()
        {
            X509Certificate2 cert = X509Helper.GetCertificateFromStore(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByIssuerName, "dotnetcode.it", false);
           
        }

        [TestMethod]
        public void GetCertifcateFromFile()
        {
            string filePath = @"C:\SourceCode\spid-dotnet-sdk\test\Developers.Italia.SPID.Test\Certificates\Hackathon\www_dotnetcode_it.pfx";

            X509Certificate2 cert = X509Helper.GetCertificateFromFile(filePath,"P@ssw0rd!");


        }

    }
}
