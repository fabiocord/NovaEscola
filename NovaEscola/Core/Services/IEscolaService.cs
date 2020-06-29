using NovaEscola.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core.Services
{
    public interface IEscolaService : IService<EscolaResource,EscolaSaveResource>
    {
        public Task<IEnumerable<EscolaResource>> Find(EscolaQueryResource query);        
        public Task<EscolaResource> SingleOrDefault(EscolaQueryResource query);
        public Task<IEnumerable<EscolaResource>> EscolasComTurmas(int pageIndex, int pageSize);
    }
}
