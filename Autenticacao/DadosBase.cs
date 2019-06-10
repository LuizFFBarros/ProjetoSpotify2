using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Autenticacao
{
    public class DadosBase
    {
        public HttpClient client;
        public AuthenticationHeaderValue Authorization;

        public string Client_ID = "944c010c52184a97bb048bcbc5d7c212";
        public string Client_Secret = "2dd7336a65b8467c8dca8e47c232a8e9";

        public DadosBase(string token)
        {
            if (string.IsNullOrEmpty(token))
                token = "BQAya1CxfAKyb5SP03w9jnHo08IoT-0qfxVmz_59HfS39RgzFLVHFPNzouupboLU9mybF6OukeBp2CYYD6hWmOH0dntjcKtO9OgClN9EErvU0UbKDMrJlPBxTIur99BbCNZrjyIDC6yNLEb1yWCp-Ls";

            Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token
                );

        }
    }
}