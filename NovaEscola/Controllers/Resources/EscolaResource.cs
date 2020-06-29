using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Controllers.Resources
{
    public class EscolaResource : BaseCadastroResource
    {     
        public string Name { get; set; }        
        public string Descricao { get; set; }        
        public DateTime DataFundacao { get; set; }
        public virtual ICollection<TurmaResource> Turmas { get; set; }

        public EscolaResource()
        {
            Turmas = new HashSet<TurmaResource>();
        }
    }
}

