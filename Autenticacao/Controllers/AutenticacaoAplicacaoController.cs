using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Autenticacao.Controllers
{
    public class AutenticacaoAplicacaoController : ApiController
    {
        public string Client_ID = "944c010c52184a97bb048bcbc5d7c212";
        public string Client_Secret = "2dd7336a65b8467c8dca8e47c232a8e9";

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/token")]
        public async void GetToken()
        {
            var param = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Client_ID}:{Client_Secret}"));
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {param}");
            HttpContent content = new FormUrlEncodedContent(args);

            HttpResponseMessage response = await client.PostAsync("https://accounts.spotify.com/api/token", content);
            string resposta = await response.Content.ReadAsStringAsync();
            var dados = JsonConvert.DeserializeAnonymousType(resposta, new object());
            DadosBase.SetToken(dados.ToString());
        }
    }
}
