using System;
using System.Net;

namespace Internet_Protocols._Task_1
{
    public class DataFinder
    {
        private readonly string _ip;
        private readonly string _asnDataBaseUrl;
        private readonly string _providerDataBaseUrl;
        private string _asnPageContent;
        private string _providerCountryPageContent;
        private const string CountryPattern = "Country:";
        private const string ProviderPattern = "StateProv:";
        private const string AsnPattern = "https://bgpview.io/asn/";
        private const string LocalAddress = "192.168.0.1";

        public DataFinder(string ip)
        {
            _ip = ip;
            _asnDataBaseUrl = $"https://bgpview.io/ip/{ip}";
            _providerDataBaseUrl = $"https://www.whois.com/whois/{ip}";
        }

        private string GetByUrl(string url)
        {
            using var client = new WebClient();
            try
            {
                return client.DownloadString(url);
            }
            catch (WebException)
            {
                Console.WriteLine($"Can't gain access to this website: {url}\n");
                throw;
            }
        }

        private string ParseContent(string content, string startPattern, string endPattern)
        {
            var startIndex = content.IndexOf(startPattern, StringComparison.Ordinal);
            if (startIndex == -1)
                return "-";
            var endIndex = content.IndexOf(endPattern, startIndex, StringComparison.Ordinal);
            var result = content
                .Substring(startIndex + startPattern.Length, endIndex - startIndex - startPattern.Length).Trim();
            return string.IsNullOrWhiteSpace(result) ? "-" : result;
        }

        public string GetAsnFromIp()
        {
            if (_ip == LocalAddress)
                return "-";
            _asnPageContent ??= GetByUrl(_asnDataBaseUrl);
            return ParseContent(_asnPageContent, AsnPattern, "\"");
        }

        public string GetCountryFromIp()
        {
            if (_ip == LocalAddress)
                return "-";
            _providerCountryPageContent ??= GetByUrl(_providerDataBaseUrl);
            return ParseContent(_providerCountryPageContent, CountryPattern, "\n");
        }

        public string GetProviderFromIp()
        {
            if (_ip == LocalAddress)
                return "-";
            _providerCountryPageContent ??= GetByUrl(_providerDataBaseUrl);
            return ParseContent(_providerCountryPageContent, ProviderPattern, "\n");
        }
    }
}