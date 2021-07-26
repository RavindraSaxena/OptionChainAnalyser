using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain
{
    public static class HttpHelper
    {
        private static bool IsCalledFirstTime=false;
        private static CookieContainer cookieContainer = new CookieContainer();
        private static int timeout = 10;

        public static void Refresh()
        {
            IsCalledFirstTime = false;
            cookieContainer = new CookieContainer();
        }
        private async static Task<string> GetHTMLWithCookies(string baseurl)
        {
            //ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //var baseurl = "https://www.nseindia.com/option-chain?symbolCode=2266&symbol=JSWSTEEL&symbol=JSWSTEEL&instrument=-&date=-&segmentLink=17&symbolCount=2&segmentLink=17";
            //var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseurl)))
                {
                    request.Headers.TryAddWithoutValidation("Accept", "*/*");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Safari/537.36");

                    var httpclient=new HttpClient(handler);
                    httpclient.Timeout = TimeSpan.FromSeconds(timeout);
                    using (var response = await httpclient.SendAsync(request).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        using (HttpContent content = response.Content)
                        {
                            return await content.ReadAsStringAsync();
                        }
                    }
                }
            }
        }

        private async static Task<string> GetHTMLOfFuturePremium(string url, List<KeyValuePair<string, string>> pair)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(timeout); ;
                var content = new FormUrlEncodedContent(pair);
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                   return await response.Content.ReadAsStringAsync();
                }
            }
            return string.Empty;
        }

        public async static Task<string> GetBhavCopy(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(timeout); ;
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            return string.Empty;
        }
        public async static Task<string> GetNSEResult(string baseurl)
        {
            try
            {
                if (!IsCalledFirstTime)
                {
                    var generateCookie = "https://www.nseindia.com/option-chain?symbolCode=2266&symbol=JSWSTEEL&symbol=JSWSTEEL&instrument=-&date=-&segmentLink=17&symbolCount=2&segmentLink=17";
                    await GetHTMLWithCookies(generateCookie);
                    IsCalledFirstTime = true;
                }

                return await GetHTMLWithCookies(baseurl);
            }
            catch(HttpRequestException ex)
            {
                if (string.Compare(ex.Message, "Response status code does not indicate success: 401 (Unauthorized).",true)==0)
                {
                    cookieContainer = new CookieContainer();
                    var generateCookie = "https://www.nseindia.com/option-chain?symbolCode=2266&symbol=JSWSTEEL&symbol=JSWSTEEL&instrument=-&date=-&segmentLink=17&symbolCount=2&segmentLink=17";
                    await GetHTMLWithCookies(generateCookie);
                    return await GetHTMLWithCookies(baseurl);
                }
            }
            return string.Empty;
        }

        public async static Task<string> GetFuturePremium(List<KeyValuePair<string, string>> pair)
        {
            return await GetHTMLOfFuturePremium("https://www.samco.in/option_fair_value_calculator/ajax_chart_display", pair);
        }
    }
}
