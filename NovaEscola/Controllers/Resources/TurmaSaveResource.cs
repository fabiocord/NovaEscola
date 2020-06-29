﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Controllers.Resources
{
    public class TurmaSaveResource : BaseResource
    {        
        public Turno Turno { get; set; }
        public string NomeTurma { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeVagas { get; set; }
        
        //public virtual SerieResource Serie { get; set; }
        public virtual int SerieId { get; set; }
        //public virtual EscolaResource Escola { get; set; }
        public virtual int EscolaId { get; set; }
    }
}
