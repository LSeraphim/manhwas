using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manhwas.Models
{
    public class DetailsVM
    {
        public Manhwa Anterior { get; set; }
        public Manhwa Atual { get; set; }
        public Manhwa Proximo { get; set; }
        public List<Genero> Generos { get; set; }

    }
}