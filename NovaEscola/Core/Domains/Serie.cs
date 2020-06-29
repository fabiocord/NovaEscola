using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Models
{
    public class Serie : IBaseEntity
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public Ensino Ensino { get; set; }        
        
    }

    public enum Ensino
    {
        Fundamental = 1,
        Medio = 2
    }
}
