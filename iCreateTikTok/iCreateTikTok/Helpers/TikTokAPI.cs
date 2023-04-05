using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace iCreateTikTok.Helpers
{
    public static class TikTokAPI
    {
        public static async Task<string> GetDataAsync(string accessToken, string baseUrl, string advertiserId, string pageId)
        {
            var uriBuilder = new UriBuilder(baseUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["advertiser_id"] = advertiserId;
            query["page_id"] = pageId;
            uriBuilder.Query = query.ToString();
            baseUrl = uriBuilder.ToString();

            string result = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Access-Token", accessToken);
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                result = data;
                            }
                            else
                            {
                                result = "No data";
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
            }
            return result;
        }
    }
}
