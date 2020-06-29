using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Models
{
    public class Escola : BaseCadastro
    {
        public Escola()
        {
            Turmas = new HashSet<Turma>();
        }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DataFundacao { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
