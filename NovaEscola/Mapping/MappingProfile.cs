using AutoMapper;
using NovaEscola.Controllers.Resources;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaEscola.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API
            
            CreateMap<Serie, SerieResource>();
            /*CreateMap<Turma, TurmaResource>()
                .ForMember(t => t.Serie, opt => opt.MapFrom(s => s.Serie))
                .ForMember(t => t.Escola, opt => opt.MapFrom(e => e.Escola));*/

            CreateMap<Turma, TurmaResource>()
                .ForMember(t => t.Serie, opt => opt.MapFrom(s => s.Serie))
                .ForMember(t => t.Escola, opt => opt.MapFrom(e => e.Escola));

            CreateMap<Escola, EscolaResource>()
                .ForMember(e => e.Turmas, opt => opt.MapFrom(t => t.Turmas));





            //API to Domain

            CreateMap<SerieResource, Serie>();

            CreateMap<EscolaResource, Escola>()
            .ForMember(e => e.Turmas, opt => opt.MapFrom(t => t.Turmas));

            CreateMap<TurmaResource, Turma>()
                .ForMember(e => e.Serie, opt => opt.Ignore())
                .ForMember(e => e.Escola, opt => opt.Ignore());
                
            
            CreateMap<TurmaSaveResource, Turma>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.SerieId, opt => opt.MapFrom(t => t.SerieId))
            .ForMember(v => v.EscolaId, opt => opt.MapFrom(t => t.EscolaId));

            CreateMap<EscolaSaveResource, Escola>()
            .ForMember(e => e.Id, opt => opt.Ignore())
            .ForMember(e => e.Turmas, opt => opt.MapFrom(t => t.Turmas));
            
            
        }

       
    }
}
