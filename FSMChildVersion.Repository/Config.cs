using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FSMChildVersion.Repository
{
    public static class Config
    {
        public static string ApiUrl = "http://makeup-api.herokuapp.com";
        public static string RedditApiUrl = "http://www.reddit.com/r";

        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }

        public static string LocalDBFile => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FSMSQLite2.db"); //
    }
}
