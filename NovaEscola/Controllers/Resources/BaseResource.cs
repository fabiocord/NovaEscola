using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Controllers.Resources
{
    public class BaseResource : IResource
    {
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;        
        public DateTime DataInclusao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
