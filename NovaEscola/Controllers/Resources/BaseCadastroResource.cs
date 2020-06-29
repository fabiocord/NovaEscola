using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Controllers.Resources
{
    public class BaseCadastroResource : BaseResource
    {        
        public int Cep { get; set; }     
        public string Lougradouro { get; set; }        
        public string Numero { get; set; }        
        public string Complemento { get; set; }        
        public string Bairro { get; set; }        
        public string Cidade { get; set; }        
        public string Uf { get; set; }        
        public string Pais { get; set; }        
        public string Email { get; set; }
        public string TelFixo { get; set; }
        public string TelMovel { get; set; }
    }
}
