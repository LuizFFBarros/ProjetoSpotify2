using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoArtista.Controllers;

namespace GestaoArtista.Negocio
{
    public class AvaliacaoArtista
    {
        public List<ArtitasRating> ArtistasRating { get; set; }

        public bool Votar(string nomeArtista, int voto, string userId)
        {
            try
            {
                var existeUser = ArtistasRating.Where(a => a.idUsuario == userId).Any();
                if (existeUser)
                {
                    var usuario = ArtistasRating.Where(a => a.idUsuario == userId).First();
                    if (usuario.ListaArtista.Where(a => a.Nome.Equals(nomeArtista)).Any())
                        usuario.ListaArtista.Where(a => a.Nome.Equals(nomeArtista)).First().Voto = voto;
                    else
                        usuario.ListaArtista.Add(new Artista { Nome = nomeArtista, Voto = voto });
                }
                else
                {
                    ArtistasRating.Add(new ArtitasRating
                    {
                        idUsuario = userId,
                        ListaArtista = new List<Artista>
                    {
                        new Artista
                        {
                            Nome = nomeArtista,
                            Voto = voto
                        }
                    }
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
