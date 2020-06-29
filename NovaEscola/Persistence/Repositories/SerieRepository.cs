using NovaEscola.Core.Repositories;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Persistence.Repositories
{
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        public SerieRepository(NovaEscolaContext context) : base(context)
        {

        }

        public NovaEscolaContext NovaEscolaContext
        {
            get { return Context as NovaEscolaContext; }
        }
    }
}
