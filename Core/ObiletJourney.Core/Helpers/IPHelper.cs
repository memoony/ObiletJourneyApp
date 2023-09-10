using Newtonsoft.Json.Linq;

namespace ObiletJourney.Core.Helpers
{
	public static class IPHelper
    {
        public static async Task<string> GetIpAddressAsync()
        {
			try
			{
				using (HttpClient httpClient = new())
				{
					HttpResponseMessage response = await httpClient.GetAsync("https://httpbin.org/ip");
					response.EnsureSuccessStatusCode();

					string responseContent = await response.Content.ReadAsStringAsync();
					JObject jsonResponse = JObject.Parse(responseContent);

					string? ipAddress = jsonResponse["origin"]?.ToString();

					if (!string.IsNullOrWhiteSpace(ipAddress))
					{
                        return ipAddress;
                    }
					else
					{
						return string.Empty;
					}
				}
			}
			catch (Exception ex)
			{

				throw new Exception("IP adresi alınırken bir hata oluştu!", ex);
			}
        }
    }
}
