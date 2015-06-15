using System;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using Thinktecture.IdentityModel;

namespace WebAPI.Tests
{
    [TestFixture]
    public class CertificateValidationTests
    {
        [Test]
        public void TestACertificate()
        {
            var cert = X509.LocalMachine.My.SubjectDistinguishedName.Find("CN=web.local", false).First();

            //ValidateUsingChain(cert);
            ValidateUsingValidator(cert);
        }

        private static void ValidateUsingChain(X509Certificate2 cert)
        {
            var chain = new X509Chain();
            var policy = new X509ChainPolicy
            {
                RevocationFlag = X509RevocationFlag.EntireChain,
                RevocationMode = X509RevocationMode.Online
            };

            chain.ChainPolicy = policy;

            if (!chain.Build(cert))
            {
                foreach (var element in chain.ChainElements)
                {
                    foreach (var status in element.ChainElementStatus)
                    {
                        Console.WriteLine(status.StatusInformation);
                    }
                }
            }
            else
            {
                Console.WriteLine("cert is trusted");
            }
        }

        private static void ValidateUsingValidator(X509Certificate2 cert)
        {
            var validator = X509CertificateValidator.ChainTrust;
            validator.Validate(cert);
        }

    }
}
