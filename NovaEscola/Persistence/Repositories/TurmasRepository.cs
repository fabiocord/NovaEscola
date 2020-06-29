using Microsoft.EntityFrameworkCore;
using NovaEscola.Core.Repositories;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Persistence.Repositories
{
    public class TurmasRepository : Repository<Turma>, ITurmasRepository
    {
        public TurmasRepository(NovaEscolaContext context) : base(context)
        {

        }
        public async Task<Turma> GetTurmaWithSerieEscola(int id)
        {
            return await NovaEscolaContext.Turmas
                .Include(e => e.Serie)
                .Include(e => e.Escola)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Turma>> GetTurmasWithSerieEscola(int pageIndex,int pageSize)
        {
            return await NovaEscolaContext.Turmas
                .Include(e => e.Serie)
                .Include(e => e.Escola)
                .OrderBy(e => e.Escola.Name)
                .OrderBy(e => e.Serie.Ensino)
                .OrderBy(e => e.Serie.Nome)
                .OrderBy(e => e.Turno)
                .OrderBy(e => e.NomeTurma)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
        }
        public NovaEscolaContext NovaEscolaContext
        {
            get { return Context as NovaEscolaContext; }
        }
    }
}
