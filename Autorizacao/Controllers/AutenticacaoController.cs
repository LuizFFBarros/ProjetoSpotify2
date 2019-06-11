using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Autorizacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        public static string Client_ID = "944c010c52184a97bb048bcbc5d7c212";
        public static string Client_Secret = "2dd7336a65b8467c8dca8e47c232a8e9";

        

        [HttpGet]
        [Route("api/token")]
        public static async Task<string> GetToken()
        {
            var param = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Client_ID}:{Client_Secret}"));
            var scopo = Convert.ToBase64String(Encoding.UTF8.GetBytes("playlist-read-private")); 
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {param}");
            client.DefaultRequestHeaders.Add("scope", scopo);

            HttpContent content = new FormUrlEncodedContent(args);

            HttpResponseMessage response = await client.PostAsync("https://accounts.spotify.com/api/token", content);
            string resposta = await response.Content.ReadAsStringAsync();
            var dados = JsonConvert.DeserializeObject<Token>(resposta);
            return dados.AccessToken;
        }
    }
}