using GestaoArtista;
using GestaoArtista.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace teste.Artista
{
    public class ArtistaTeste
    {
        [Theory]
        [InlineData("Phill Colins",     5, "A1")]
        [InlineData("Imagine Dragons",  3, "A1")]
        [InlineData("The Weeknd",       5, "A2")]
        [InlineData("Maroon 5.",        2, "A2")]
        public void TestaVoto(string nomeArtista, int voto, string userId)
        {
            AvaliacaoArtista avaliacao = new AvaliacaoArtista();
            avaliacao.ArtistasRating = new List<ArtitasRating>();

            var rep = avaliacao.Votar(nomeArtista, voto, userId);
            Assert.True(rep);
            
        }
    }
}
