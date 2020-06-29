using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Controllers.Resources
{
    public class SerieQueryResource
    {
        public string Nome { get; set; } = null;
        public Ensino Ensino { get; set; } = Ensino.Fundamental;

    }
}
