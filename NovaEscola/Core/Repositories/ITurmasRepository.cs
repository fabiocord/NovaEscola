using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core.Repositories
{
    public interface ITurmasRepository : IRepository<Turma>
    {
        Task<Turma> GetTurmaWithSerieEscola(int id);
        Task<IEnumerable<Turma>> GetTurmasWithSerieEscola(int pageIndex, int pageSize);
    }
}
