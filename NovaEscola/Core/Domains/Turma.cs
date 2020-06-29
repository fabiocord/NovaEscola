using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Models
{
    public class Turma : BaseEntity
    {               
        public Turno Turno { get; set; }
        public string NomeTurma { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeVagas { get; set; } = 0;
        public virtual Serie Serie { get; set; }
        public int SerieId { get; set; }
        public virtual Escola Escola { get; set; }
        public int EscolaId { get; set; }
    }

    public enum Turno
    {
        Manha = 1,
        Tarde = 2,
        Noite = 3
    }

    
}
