using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Models
{
    public class BaseCadastro: BaseEntity
    {
        [Required]
        [StringLength(8)]
        [DisplayFormat(DataFormatString = "{00000-000}")]
        public int Cep { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string Lougradouro { get; set; }
        [Required]
        [StringLength(6)]
        public string Numero { get; set; }
        
        [StringLength(100)]
        public string Complemento { get; set; }
        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }
        [Required]
        [StringLength(255)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(2)]
        public string Uf { get; set; }
        [Required]
        [StringLength(100)]
        public string Pais { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string TelFixo { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string TelMovel { get; set; }      

    }
}
