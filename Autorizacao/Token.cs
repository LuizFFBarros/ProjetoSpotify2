using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autorizacao
{
    public class Token
    {
        //{[access_token, BQBSrn38nJf1dPI3jG_K721JgHrPnT99HVwTYMRzJawxJtKQTz0W8jTKWVM02cRzvRaswEogkj3axxCZ0UA]}	System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>
        //{[token_type, Bearer]}	System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>
        //{[expires_in, 3600]}	System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>
        //{[scope, ]}	System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        ///     Checks if the token has expired
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return CreateDate.Add(TimeSpan.FromSeconds(ExpiresIn)) <= DateTime.Now;
        }

        public bool HasError()
        {
            return Error != null;
        }

    }
}
