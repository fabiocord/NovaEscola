using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Models
{
    public interface IBaseEntity
    {
        int Id { get; set; }        
    }
}
