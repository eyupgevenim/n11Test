using System;
using System.Configuration;

namespace n11Test.core.browsers
{
    public static class Config
    {
        public static BrowserType Browser
            => (BrowserType)Enum.Parse(typeof(BrowserType), GetValue("Browser"));
        
        public static string BaseUrl => GetValue("BaseUrl");
        public static string Username => GetValue("Username");
        public static string Password => GetValue("Password");

        private static string GetValue(string value)
        {
            return ConfigurationManager.AppSettings[value];
        }
    }
}
