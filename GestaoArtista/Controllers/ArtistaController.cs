using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Autorizacao;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestaoArtista.Controllers
{
    [Route("api/atista")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        string adressBase = "https://api.spotify.com/v1";

        public static AuthenticationHeaderValue Authorization;

        [HttpGet("{nome}")]
        public async Task<string> Artistas(string nome)
        {
            var token = await Autorizacao.Controllers.AutenticacaoController.GetToken();
            Authorization = new AuthenticationHeaderValue("Bearer", token);

            var queryParams = new NameValueCollection()
            {
                { "q", nome },
                { "type", "artist" },
            };


            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = Authorization;

            var request = client.GetAsync($"{adressBase}/search{ToQueryString(queryParams)}");
            var response = await request.Result.Content.ReadAsStringAsync();

            return response;

        }


        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array).Replace("+", "%20");
        }
    }
}