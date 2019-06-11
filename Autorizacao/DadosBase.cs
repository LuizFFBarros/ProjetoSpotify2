using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Autorizacao
{
    public static class DadosBase
    {
        public static HttpClient client;
        public static AuthenticationHeaderValue Authorization;
        public static string _token = "";

        public static string Client_ID = "944c010c52184a97bb048bcbc5d7c212";
        public static string Client_Secret = "2dd7336a65b8467c8dca8e47c232a8e9";

        public static string GetToken()
        {
            return _token;
        }

        public static void SetToken(string token)
        {
            _token = token;
            Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token
                );
        }

    }
}
