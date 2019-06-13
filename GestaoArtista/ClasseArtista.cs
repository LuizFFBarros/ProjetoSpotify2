using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoArtista
{
    public class ClasseArtista
    {

    }
    public class ArtitasRating
    {
        public List<Artista> ListaArtista { get; set; }
        public string idUsuario { get; set; }
    }
    public class Artista
    {
        public string ArtistaId { get; set; }
        public string Nome { get; set; }
        public int Voto { get; set; }
    }
}
