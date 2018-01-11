using System;
using DotNetCode.SPID;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetCode.Spid.Factory;
using DotNetCode.Spid;
using DotNetCode.Spid.SAML;

namespace DotNetCode.SPID.Test
{
    [TestClass]
    public class IdentityProviderFactoryTest
    {
        [TestMethod]
        public void GetIdentityProvider()
        {
            IdentityProvider test = IdentityProviderFactory.GetIdentityProvider("Test", Spid.SpidProviderType.Saml2);

            Assert.IsTrue(test.Settings.ContainsKey(SamlSettings.AssertionConsumerServiceIndex));

        }
    }
}
