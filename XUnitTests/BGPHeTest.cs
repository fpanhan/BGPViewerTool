using System.Collections.Generic;
using System.Linq;
using BGPViewerCore.Service;

namespace Xunit
{
    public class BGPHeTest : IClassFixture<BGPHeMockWebDriver>
    {
        private IBGPViewerService Service { get; }

        public BGPHeTest(BGPHeMockWebDriver driver)
        {
            Service = new BGPHeService(driver, 7);
        }

        [Fact]
        public void GetAsnDetails()
        {
            var retrievedAsnDetails = Service.GetAsnDetails(15169);
            Assert.Equal(15169, retrievedAsnDetails.ASN);   
            Assert.Equal("Google LLC", retrievedAsnDetails.Name);   
            Assert.Equal("Google LLC", retrievedAsnDetails.Description);   
            Assert.Equal("US", retrievedAsnDetails.CountryCode);
            Assert.Equal(string.Join(", ", new string[]{"arin-contact@google.com", "network-abuse@google.com", "arin-contact@google.com"}), string.Join(", ", retrievedAsnDetails.EmailContacts));
            Assert.Equal(string.Join(", ", new string[]{"arin-contact@google.com", "network-abuse@google.com", "arin-contact@google.com"}), string.Join(", ", retrievedAsnDetails.AbuseContacts));
            Assert.Null(retrievedAsnDetails.LookingGlassUrl);

            retrievedAsnDetails = Service.GetAsnDetails(268003);
            Assert.Equal(268003, retrievedAsnDetails.ASN);   
            Assert.Equal("CITY NET INTERNET EIRELI ME", retrievedAsnDetails.Name);   
            Assert.Equal("CITY NET INTERNET EIRELI ME", retrievedAsnDetails.Description);   
            Assert.Equal("BR", retrievedAsnDetails.CountryCode);
            Assert.Equal(string.Join(", ", new string[]{"citynet.telecom@hotmail.com"}), string.Join(", ", retrievedAsnDetails.EmailContacts));
            Assert.Equal(string.Join(", ", new string[]{"citynet.telecom@hotmail.com"}), string.Join(", ", retrievedAsnDetails.AbuseContacts));
            Assert.Null(retrievedAsnDetails.LookingGlassUrl);

            retrievedAsnDetails = Service.GetAsnDetails(53181);
            Assert.Equal(53181, retrievedAsnDetails.ASN);   
            Assert.Equal("K2 Telecom e Multimidia LTDA ME", retrievedAsnDetails.Name);   
            Assert.Equal("K2 Telecom e Multimidia LTDA ME", retrievedAsnDetails.Description);   
            Assert.Equal("BR", retrievedAsnDetails.CountryCode);
            Assert.Equal(string.Join(", ", new string[]{"engenharia@k2telecom.com.br"}), string.Join(", ", retrievedAsnDetails.EmailContacts));
            Assert.Equal(string.Join(", ", new string[]{"engenharia@k2telecom.com.br"}), string.Join(", ", retrievedAsnDetails.AbuseContacts));
            Assert.Equal("https://lg.k2telecom.net.br/", retrievedAsnDetails.LookingGlassUrl);
        }

        [Fact]
        public void GetDetailsFromNonExistentAsn()
        {
            Assert.Throws<KeyNotFoundException>(() => Service.GetAsnDetails(-1));
        }

        [Fact]
        public void GetAsnDownstreamsShouldAlwaysReturnEmptyObjects()
        {
            Assert.Empty(Service.GetAsnDownstreams(15169).Item1);
            Assert.Empty(Service.GetAsnDownstreams(15169).Item2);
            Assert.Empty(Service.GetAsnDownstreams(268003).Item1);
            Assert.Empty(Service.GetAsnDownstreams(268003).Item2);
            Assert.Empty(Service.GetAsnDownstreams(53181).Item1);
            Assert.Empty(Service.GetAsnDownstreams(53181).Item2);
        }

        [Fact]
        public void GetAsnIxs()
        {   
            var ixs = Service.GetAsnIxs(268003);
            Assert.Empty(ixs);

            ixs = Service.GetAsnIxs(15169);
            var firstIx = ixs.First();
            Assert.Equal("AMS-IX", firstIx.Name);
            Assert.Equal("AMS-IX", firstIx.FullName);
            Assert.Equal("NL", firstIx.CountryCode);
            Assert.Equal("80.249.208.247", firstIx.IPv4);
            Assert.Equal("2001:7f8:1::a501:5169:2", firstIx.IPv6);

            var lastIx = ixs.Last();
            Assert.Equal("YYCIX", lastIx.Name);
            Assert.Equal("YYCIX", lastIx.FullName);
            Assert.Equal("CA", lastIx.CountryCode);
            Assert.Equal("206.126.225.128", lastIx.IPv4);
            Assert.Equal("2001:504:2f::1:5169:1", lastIx.IPv6);
        }

        [Fact]
        public void AsnIxSpeedShouldAlwaysBeZeroWhenApiDoesNotProvideThisInformation()
        {
            var ixs = Service.GetAsnIxs(15169);
            Assert.True(ixs.Count(ix => ix.AsnSpeed == 0) == ixs.Count());
            ixs = Service.GetAsnIxs(268003);
            Assert.True(ixs.Count(ix => ix.AsnSpeed == 0) == ixs.Count());
            ixs = Service.GetAsnIxs(53181);
            Assert.True(ixs.Count(ix => ix.AsnSpeed == 0) == ixs.Count());
        }
    }
}