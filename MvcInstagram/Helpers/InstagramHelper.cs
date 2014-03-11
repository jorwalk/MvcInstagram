using System.Collections.Generic;
using InstaSharp;

namespace MvcInstagram.Helpers
{
    public class InstagramHelper
    {
        public const string ClientId = "ce1818b7e1334bdf9f49e89de7045e7a";
        public const string ClientSecret = "668fee6062ca4c9b863fa979d8f45c9d";

        public const string ClientUrl = "http://localhost:2339/";
        public const string RedirectUrl = "http://localhost:2339/Instagram/OauthRedirect";

        private const string ApiUrl = "https://api.instagram.com/v1";
        private const string OauthUrl = "https://api.instagram.com/oauth";

        public const string AccessToken = "184083663.ce1818b.b94e7d1a4af84cb9abcd1b9230d36727";
        public const int UserId = 184083663;
        public const string UserName = "jordanwa1ker";


        public static InstagramConfig GetConfig()
        {
            var cfg = new InstagramConfig(ApiUrl, OauthUrl, ClientId, ClientSecret, RedirectUrl);
            return cfg;
        }
        public static Auth GetAuth()
        {
            var auth = new Auth(GetConfig());
            return auth;
        }
        public static AuthInfo GetAuthInfo()
        {
            var authInfo = new AuthInfo
            {
                Access_Token = AccessToken,
                Config = GetConfig(),
            };
            return authInfo;
        }
        public static UserInfo GetUserInfo()
        {
            var userInfo = new UserInfo
            {
                Id = UserId,
                Username = UserName,
            };
            return userInfo;
        }
        public static string GetBasicAuthLink()
        {
            var authScope = new List<Auth.Scope>
            {
                Auth.Scope.basic
            };
            return Auth.AuthLink(OauthUrl, ClientId, RedirectUrl, authScope);
        }
        public static string GetRelationshipsAuthLink()
        {
            var authScope = new List<Auth.Scope>
            {
                Auth.Scope.basic,
                Auth.Scope.relationships
            };
            return Auth.AuthLink(OauthUrl, ClientId, RedirectUrl, authScope);
        }

    }
}
