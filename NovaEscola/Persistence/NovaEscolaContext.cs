using Microsoft.EntityFrameworkCore;
using NovaEscola.Core.Domains.Configuration;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Persistence
{
    public class NovaEscolaContext : DbContext
    {
        public NovaEscolaContext(DbContextOptions<NovaEscolaContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EscolaConfiguration());
            modelBuilder.ApplyConfiguration(new SerieConfiguration());
            modelBuilder.ApplyConfiguration(new TurmaConfiguration());
           
          
        }
                
        public DbSet<Escola> Escolas { get; set; }        
        public DbSet<Serie> Series { get; set; }
        public DbSet<Turma> Turmas { get; set; }        
    }   
}
