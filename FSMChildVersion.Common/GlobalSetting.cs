using System;
using System.Collections.Generic;
using System.Text;

namespace FSMChildVersion
{
    public class GlobalSetting
    {
        public static string ServerURL
        {
            get => _serverURL;
            set => _serverURL = value;
        }

        private static string _serverURL = ""; //"http://fsmbeta.itlinksolutions.com";
        public void SetterOfDefaultEndpoint(string _serverURL = "")
        {
            ServerURL = _serverURL;
            DefaultEndpointLogin = ServerURL + "/RestApis";
            DefaultEndpoint = ServerURL + "/RestApis";
            RootURL = ServerURL;
            LocationEndpoint = ServerURL + "/Location";
            UpdateEndpoint(DefaultEndpointLogin);
        }
        public static string DefaultEndpointLogin = ServerURL + "/RestApis";
        public static string DefaultEndpoint = ServerURL + "/RestApis";
        public static string RootURL = ServerURL;
        public static string LocationEndpoint = ServerURL + "/Location";

        private string _baseIdentityEndpoint;


        public GlobalSetting()
        {
            AuthToken = string.Empty;
            BaseIdentityEndpoint = DefaultEndpointLogin;
        }

        public static GlobalSetting Instance { get; } = new GlobalSetting();

        public string BaseIdentityEndpoint
        {
            get => _baseIdentityEndpoint;
            set
            {
                _baseIdentityEndpoint = value;
                UpdateEndpoint(_baseIdentityEndpoint);
            }
        }

        public string ClientId => "xamarin";

        public string ClientSecret => "ajksd4jksakjd&kjhsa,mdwuejadhaal;kdhiuqwgbnzlkadho";

        public string AuthToken { get; set; }

        public string AuthorizeEndpoint { get; set; }

        public string UserInfoEndpoint { get; set; }

        public string TokenEndpoint { get; set; }

        public string LogoutEndpoint { get; set; }

        public string Callback { get; set; }

        public string LogoutCallback { get; set; }
        public string PasswordResetEndPoint { get; set; }
        private void UpdateEndpoint(string endpoint)
        {
            LogoutCallback = $"{endpoint}/Account/Redirecting";
            PasswordResetEndPoint = $"{endpoint}/Login/ForgotPassword";

            AuthorizeEndpoint = $"{endpoint}/Security";

            string connectBaseEndpoint = $"{endpoint}/connect";
            UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
            TokenEndpoint = $"{connectBaseEndpoint}/token";
            LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

            string baseUri = ExtractBaseUri(endpoint);
            Callback = $"{baseUri}/xamarincallback";
        }

        private string ExtractBaseUri(string endpoint)
        {
            try
            {
                return new Uri(endpoint).GetLeftPart(UriPartial.Authority);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
