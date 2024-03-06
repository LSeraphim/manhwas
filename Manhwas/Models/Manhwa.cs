using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manhwas.Models
{
    public class Manhwa
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public List<string> Genero { get; set; } = [];
        public string Imagem { get; set; }
    }
}