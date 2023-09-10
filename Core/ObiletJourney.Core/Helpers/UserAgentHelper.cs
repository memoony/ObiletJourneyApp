using System.Text.RegularExpressions;

namespace ObiletJourney.Core.Helpers
{
    public static class UserAgentHelper
    {
        public static string GetBrowserName(string userAgent)
        {
            string browserName = "Bilinmiyor";

            if (userAgent.Contains("Chrome"))
            {
                browserName = "Chrome";
            }
            else if (userAgent.Contains("Firefox"))
            {
                browserName = "Firefox";
            }
            else if (userAgent.Contains("Opera"))
            {
                browserName = "Opera";
            }
            else if (userAgent.Contains("Edge"))
            {
                browserName = "Edge";
            }

            return browserName;
        }

        public static string GetBrowserVersion(string userAgent)
        {
            string browserVersion = "Bilinmiyor";

            // Google Chrome Versiyonu
            var chromeMatch = Regex.Match(userAgent, @"Chrome/(\d+\.\d+)");
            if (chromeMatch.Success)
            {
                browserVersion = chromeMatch.Groups[1].Value;
            }

            // Mozilla Firefox Versiyonu
            var firefoxMatch = Regex.Match(userAgent, @"Firefox/(\d+\.\d+)");
            if (firefoxMatch.Success)
            {
                browserVersion = firefoxMatch.Groups[1].Value;
            }

            // Opera Versiyonu
            var operaMatch = Regex.Match(userAgent, @"Opera/(\d+\.\d+)");
            if (operaMatch.Success)
            {
                browserVersion = operaMatch.Groups[1].Value;
            }

            // Microsoft Edge Versiyonu
            var edgeMatch = Regex.Match(userAgent, @"Edge/(\d+\.\d+)");
            if (edgeMatch.Success)
            {
                browserVersion = edgeMatch.Groups[1].Value;
            }

            return browserVersion;
        }
    }
}
