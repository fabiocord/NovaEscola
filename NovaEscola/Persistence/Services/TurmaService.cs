using AutoMapper;
using NovaEscola.Controllers.Resources;
using NovaEscola.Core;
using NovaEscola.Core.Repositories;
using NovaEscola.Core.Services;
using NovaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NovaEscola.Persistence.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        

        public TurmaService(IUnitOfWork unitOfWork, IMapper mapper)
        {            
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TurmaResource>> Find(TurmaQueryResource query)
        {
            try
            {
                ParameterExpression argParam = Expression.Parameter(typeof(Turma), "e");
                Expression nameProperty = Expression.Property(argParam, "NomeTurma");                
                var val1 = (query.NomeTurma != null) ? Expression.Constant(query.NomeTurma) : null;   
                
                var andExp = (val1 != null) ? Expression.Equal(nameProperty, val1) : null;

                var lambda = (andExp != null) ? Expression.Lambda<Func<Turma, bool>>(andExp, argParam) : null;

                if (lambda == null)
                    throw new Exception("Informe ao menos um parâmetro para a consulta");
                var turmas = await unitOfWork.Turmas.Find(lambda);
                var turmasResource = mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaResource>>(turmas);
                return turmasResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TurmaResource> SingleOrDefault(TurmaQueryResource query)
        {
            try
            {

                ParameterExpression argParam = Expression.Parameter(typeof(Turma), "e");
                Expression nameProperty = Expression.Property(argParam, "NomeTurma");
                var val1 = (query.NomeTurma != null) ? Expression.Constant(query.NomeTurma) : null;
                var andExp = (val1 != null) ? Expression.Equal(nameProperty, val1) : null;
                var lambda = (andExp != null) ? Expression.Lambda<Func<Turma, bool>>(andExp, argParam) : null;

                if (lambda == null)
                    throw new Exception("Informe ao menos um parâmetro para a consulta");

                var turma = await unitOfWork.Turmas.SingleOrDefault(lambda);
                var turmaResource = mapper.Map<Turma, TurmaResource>(turma);
                return turmaResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<TurmaResource>> TurmasWithSerieEscola(int pageIndex, int pageSize)
        {
            try
            {
                var turmas = await unitOfWork.Turmas.GetTurmasWithSerieEscola(pageIndex,pageSize);
                var turmasResource = mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaResource>>(turmas);
                return turmasResource;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TurmaResource> Get(int id)
        {
            try
            {
                var turma = await unitOfWork.Turmas.GetTurmaWithSerieEscola(id);
                var turmaResource = mapper.Map<Turma, TurmaResource>(turma);
                return turmaResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TurmaResource>> GetAll()
        {
            try
            {
                var turmas = await unitOfWork.Turmas.GetAll();
                var turmasResource = mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaResource>>(turmas);
                return turmasResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TurmaResource> Create(TurmaSaveResource entity)
        {            
            try
            {
                var turma = mapper.Map<TurmaSaveResource, Turma>(entity);
                unitOfWork.Turmas.Add(turma);
                await unitOfWork.CompleteAsync();
                var turmaReturn = await unitOfWork.Turmas.Get(turma.Id);
                var turmaResource = mapper.Map<Turma, TurmaResource>(turmaReturn);
                return turmaResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TurmaResource> Update(TurmaSaveResource entity)
        {
            try
            {
                var turmaBase = await unitOfWork.Turmas.Get(entity.Id);
                var turma = mapper.Map<TurmaSaveResource, Turma>(entity,turmaBase);
                turma.DataModificacao = DateTime.Now;
                await unitOfWork.CompleteAsync();
                turma = await unitOfWork.Turmas.Get(turma.Id);
                var turmaResource = mapper.Map<Turma, TurmaResource>(turma);
                return turmaResource;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var turma = await unitOfWork.Turmas.Get(id);
                unitOfWork.Turmas.Remove(turma);
                await unitOfWork.CompleteAsync();
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
