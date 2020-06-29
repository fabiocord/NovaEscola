using Microsoft.EntityFrameworkCore;
using NovaEscola.Core.Repositories;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Persistence.Repositories
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {

        public EscolaRepository(NovaEscolaContext context) : base(context)
        {
        }

        public async Task<Escola> GetEscolaWithSerieTurma(int id)
        {
            return await NovaEscolaContext.Escolas
                .Include(e => e.Turmas)
                    .ThenInclude(t => t.Serie)                    
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Escola>> GetEscolasWithTurmas(int pageIndex, int pageSize)
        {
            try
            {
                var escolas = await NovaEscolaContext.Escolas
               .Include(e => e.Turmas)
                .ThenInclude(t => t.Serie)
               .OrderBy(e => e.Name)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();
               return escolas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
               
        public NovaEscolaContext NovaEscolaContext
        {
            get { return Context as NovaEscolaContext; }
        }
    }
}
