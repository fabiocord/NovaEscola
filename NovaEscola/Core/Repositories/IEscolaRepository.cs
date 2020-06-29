using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core.Repositories
{
    public interface IEscolaRepository : IRepository<Escola>
    {
        Task<Escola> GetEscolaWithSerieTurma(int id);
        Task <IEnumerable<Escola>> GetEscolasWithTurmas(int pageIndex, int pageSize);
    }
}
