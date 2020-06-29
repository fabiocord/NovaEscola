using NovaEscola.Core;
using NovaEscola.Core.Repositories;
using NovaEscola.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NovaEscolaContext _context;

        public UnitOfWork(NovaEscolaContext context)
        {
            _context = context;
            Escolas = new EscolaRepository(_context);
            Turmas = new TurmasRepository(_context);
            Series = new SerieRepository(_context);
        }
        public IEscolaRepository Escolas { get; set; }
        public ITurmasRepository Turmas { get; set; }
        public ISerieRepository Series { get; set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
