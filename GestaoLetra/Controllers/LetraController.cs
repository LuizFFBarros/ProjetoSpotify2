using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLetra.Controllers
{
    [Route("api/letra")]
    [ApiController]
    public class LetraController : ControllerBase
    {
        string adressBase = "http://api.musixmatch.com/ws/1.1";

        [HttpGet]
        [Route("{musica}")]
        public async Task<string> MusicaAsync(string musica)
        {
            var token = BaseDados.GetToken;
            var client = new HttpClient();

            var queryParams = new NameValueCollection()
            {
                { "q_track", musica},
                
            };
            var url = $"{adressBase}/track.search{ToQueryString(queryParams)}&apikey={token}";
            var request = client.GetAsync(url);
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