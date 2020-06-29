using NovaEscola.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core.Services
{     
    public interface ITurmaService : IService<TurmaResource,TurmaSaveResource>
    {
        Task<IEnumerable<TurmaResource>> TurmasWithSerieEscola(int pageIndex, int pageSize);
        public Task<IEnumerable<TurmaResource>> Find(TurmaQueryResource query);        
        public Task<TurmaResource> SingleOrDefault(TurmaQueryResource query);
    }
}
