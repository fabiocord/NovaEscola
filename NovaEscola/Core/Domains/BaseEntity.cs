using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Models
{
    public class BaseEntity : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("true")]        
        public bool Ativo { get; set; } = true;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("CURRENT_DATE")]
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("CURRENT_DATE")]
        public DateTime DataModificacao { get; set; } = DateTime.Now;
    }
}
