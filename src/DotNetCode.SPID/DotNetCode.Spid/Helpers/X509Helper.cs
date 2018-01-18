using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DotNetCode.Spid.Helpers
{
    public static class X509Helper
    {

        /// <summary>
        /// Gets the certificate from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static X509Certificate2 GetCertificateFromFile(string fileName)
        {
            return GetCertificateFromFile(fileName, "");
        }


        public static X509Certificate2 GetCertificateFromFile(string fileName, string password)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Invalid certificate file", fileName);
            }
            else
            {

                if (string.IsNullOrEmpty(password))
                {
                    return new X509Certificate2(fileName,"", X509KeyStorageFlags.Exportable);
                }
                else
                {
                    return new X509Certificate2(fileName, password, X509KeyStorageFlags.Exportable);
                }

            }
        }

        /// <summary>
        /// Gets the certificate from store.
        /// </summary>
        /// <param name="storeLocation">The store location.</param>
        /// <param name="storeName">Name of the store.</param>
        /// <param name="findType">Type of the find.</param>
        /// <param name="findValue">The find value.</param>
        /// <param name="validOnly">if set to <c>true</c> [valid only].</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The findValue parameter can't be null.</exception>
        /// <exception cref="FileNotFoundException">Unable to locate certificate</exception>
        public static X509Certificate2 GetCertificateFromStore(StoreLocation storeLocation, StoreName storeName, X509FindType findType, object findValue, bool validOnly)
        {
            X509Certificate2 certificate = null;

            if (findValue == null)
            {
                throw new ArgumentNullException("findValue");
            }

            try
            {
                X509Store store = new X509Store(storeName, storeLocation);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                X509Certificate2Collection coll = store.Certificates.Find(findType, findValue.ToString(), validOnly);

                if (coll.Count > 0)
                {
                    certificate = coll[0];
                }
                store.Close();

                return certificate;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static X509Certificate2 GetCertificateFromStoreByIssuerName(string issuerName)
        {
            return GetCertificateFromStoreByIssuerName(issuerName, true);
        }

        public static X509Certificate2 GetCertificateFromStoreByIssuerName(string issuerName, bool validOnly)
        {
            return GetCertificateFromStore(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByIssuerName, issuerName, validOnly);
        }
    }
}
