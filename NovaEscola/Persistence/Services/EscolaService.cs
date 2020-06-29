using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class EscolaService : IEscolaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public EscolaService(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }
        public async Task<EscolaResource> Get(int id)
        {
            try
            {
                var escola = await unitOfWork.Escolas.GetEscolaWithSerieTurma(id);
                var escolaResource = mapper.Map<Escola, EscolaResource>(escola);
                return escolaResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public async Task<IEnumerable<EscolaResource>> GetAll()
        {
            try
            {
                var escolas = await unitOfWork.Escolas.GetAll();
                var escolasResource = mapper.Map<IEnumerable<Escola>, IEnumerable<EscolaResource>>(escolas);
                return escolasResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<IEnumerable<EscolaResource>> Find(EscolaQueryResource query)
        {
            try
            {
                ParameterExpression argParam = Expression.Parameter(typeof(Escola), "e");
                Expression nameProperty = Expression.Property(argParam, "Name");
                Expression ufProperty = Expression.Property(argParam, "Uf");

                var val1 = Expression.Constant(query.Name);
                var val2 = Expression.Constant(query.UF);

                List <Expression> listExpression = new List<Expression>();

                if (query.Name != null)
                    listExpression.Add(Expression.Equal(nameProperty, val1));
                if (query.UF != null)
                    listExpression.Add(Expression.Equal(ufProperty, val2));


                var andExp = (listExpression.Count > 1) ? Expression.AndAlso(listExpression[0], listExpression[1]) : (listExpression.Count == 1) ? listExpression[0] : null;

                var lambda = (andExp != null) ? Expression.Lambda<Func<Escola, bool>>(andExp, argParam) : null;

                if (lambda == null)
                    throw new Exception("Informe ao menos um parâmetro para a consulta");
                var escolas = await unitOfWork.Escolas.Find(lambda);
                var escolasResource = mapper.Map<IEnumerable<Escola>, IEnumerable<EscolaResource>>(escolas);
                return escolasResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EscolaResource> SingleOrDefault(EscolaQueryResource query)
        {
            try
            {
                ParameterExpression argParam = Expression.Parameter(typeof(Escola), "e");
                Expression nameProperty = Expression.Property(argParam, "Name");
                Expression ufProperty = Expression.Property(argParam, "Uf");

                var val1 = Expression.Constant(query.Name);
                var val2 = Expression.Constant(query.UF);

                List<Expression> listExpression = new List<Expression>();

                if (query.Name != null)
                    listExpression.Add(Expression.Equal(nameProperty, val1));
                if (query.UF != null)
                    listExpression.Add(Expression.Equal(ufProperty, val2));


                var andExp = (listExpression.Count > 1) ? Expression.AndAlso(listExpression[0], listExpression[1]) : (listExpression.Count == 1) ? listExpression[0] : null;

                var lambda = (andExp != null) ? Expression.Lambda<Func<Escola, bool>>(andExp, argParam) : null;

                if (lambda == null)
                    throw new Exception("Informe ao menos um parâmetro para a consulta");

                var escola = await unitOfWork.Escolas.SingleOrDefault(lambda);
                var escolaResource = mapper.Map<Escola, EscolaResource>(escola);
                return escolaResource;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<EscolaResource>> EscolasComTurmas(int pageIndex, int pageSize)
        {
            try
            {
                var escolas = await unitOfWork.Escolas.GetEscolasWithTurmas(pageIndex, pageSize);                
                var escolasResource = mapper.Map<IEnumerable<Escola>, IEnumerable<EscolaResource>>(escolas);
                return escolasResource;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EscolaResource> Create(EscolaSaveResource entity)
        {
            try
            {
                var escola = mapper.Map<EscolaSaveResource, Escola>(entity);                
                unitOfWork.Escolas.Add(escola);                           
                await unitOfWork.CompleteAsync();
                var escolaReturn = await unitOfWork.Escolas.Get(escola.Id);
                var escolaResource = mapper.Map<Escola, EscolaResource>(escolaReturn);
                return escolaResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<EscolaResource> Update(EscolaSaveResource entity)
        {
            try
            {
                var escolaBase = await unitOfWork.Escolas.Get(entity.Id);                
                var escola = mapper.Map<EscolaSaveResource, Escola>(entity,escolaBase);                 
                escola.DataModificacao = DateTime.Now;                
                await unitOfWork.CompleteAsync();
                escola = await unitOfWork.Escolas.Get(entity.Id);
                var escolaResource = mapper.Map<Escola, EscolaResource>(escola);
                return escolaResource;
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
                var escola = await unitOfWork.Escolas.Get(id);
                unitOfWork.Escolas.Remove(escola);
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
