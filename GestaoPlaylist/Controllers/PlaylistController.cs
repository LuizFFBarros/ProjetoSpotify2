using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPlaylist.Controllers
{
    [Route("api/playlist")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        string adressBase = "https://api.spotify.com/v1";
        public static AuthenticationHeaderValue Authorization;



        [HttpGet]
        [Route("me")]
        public async Task<string> PlaylistAsync()
        {
        
            var token = await Autorizacao.Controllers.AutenticacaoController.GetToken();
            Authorization = new AuthenticationHeaderValue("Bearer", token);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = Authorization;

            var request = client.GetAsync($"{adressBase}/me/playlists");
            var response = await request.Result.Content.ReadAsStringAsync();

            return response;

        }
    }
}