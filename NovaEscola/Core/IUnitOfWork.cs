using NovaEscola.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEscolaRepository Escolas { get; }
        ITurmasRepository Turmas { get; set; }
        ISerieRepository Series { get; set; }
        Task CompleteAsync();
    }
}
