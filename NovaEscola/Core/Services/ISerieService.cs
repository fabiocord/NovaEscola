using NovaEscola.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core.Services
{
    public interface ISerieService : IService<SerieResource,SerieResource>
    {
        public Task<IEnumerable<SerieResource>> Find(SerieQueryResource query);
        public Task<SerieResource> SingleOrDefault(SerieQueryResource query);
    }
}
