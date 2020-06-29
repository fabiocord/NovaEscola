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
    public class SerieService : ISerieService
    {
        private readonly IUnitOfWork unitOfWork;        
        private readonly IMapper mapper;

        public SerieService(IUnitOfWork unitOfWork, IMapper mapper)
        {            
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SerieResource>> Find(SerieQueryResource query)
        {
            try
            {
                ParameterExpression argParam = Expression.Parameter(typeof(Serie), "e");                
                Expression nameProperty = Expression.Property(argParam, "Nome");
                Expression ensinoProperty = Expression.Property(argParam, "Ensino");

                var val1 = Expression.Constant(query.Nome);
                var val2 = Expression.Constant(query.Ensino);

                List<Expression> listExpression = new List<Expression>();

                if (val1 != null)
                    listExpression.Add(Expression.Equal(nameProperty, val1));
                if (val2 != null)
                    listExpression.Add(Expression.Equal(ensinoProperty, val2));


                var andExp = (listExpression.Count > 1) ? Expression.AndAlso(listExpression[0], listExpression[1]) : (listExpression.Count == 1) ? listExpression[0] : null;

                var lambda = (andExp != null) ? Expression.Lambda<Func<Serie, bool>>(andExp, argParam) : null;

                if (lambda == null)
                    throw new Exception("Informe ao menos um parâmetro para a consulta");
                var series = await unitOfWork.Series.Find(lambda);
                var seriesResource = mapper.Map<IEnumerable<Serie>, IEnumerable<SerieResource>>(series);
                return seriesResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SerieResource> SingleOrDefault(SerieQueryResource query)
        {
            try
            {
                ParameterExpression argParam = Expression.Parameter(typeof(Serie), "e");
                Expression nameProperty = Expression.Property(argParam, "Nome");
                Expression ensinoProperty = Expression.Property(argParam, "Ensino");

                var val1 = Expression.Constant(query.Nome);
                var val2 = Expression.Constant(query.Ensino);

                List<Expression> listExpression = new List<Expression>();

                if (val1 != null)
                    listExpression.Add(Expression.Equal(nameProperty, val1));
                if (val2 != null)
                    listExpression.Add(Expression.Equal(ensinoProperty, val2));


                var andExp = (listExpression.Count > 1) ? Expression.AndAlso(listExpression[0], listExpression[1]) : (listExpression.Count == 1) ? listExpression[0] : null;

                var lambda = (andExp != null) ? Expression.Lambda<Func<Serie, bool>>(andExp, argParam) : null;

                if (lambda == null)
                    throw new Exception("Informe ao menos um parâmetro para a consulta");
                var serie = await unitOfWork.Series.SingleOrDefault(lambda);
                var seriesResource = mapper.Map<Serie, SerieResource>(serie);
                return seriesResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<SerieResource> Get(int id)
        {
            try
            {
                var serie = await unitOfWork.Series.Get(id);
                var serieResource = mapper.Map<Serie, SerieResource>(serie);
                return serieResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SerieResource>> GetAll()
        {
            try
            {
                var series = await unitOfWork.Series.GetAll();
                var seriesResource = mapper.Map<IEnumerable<Serie>, IEnumerable<SerieResource>>(series);
                return seriesResource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public Task<SerieResource> Create(SerieResource entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task<SerieResource> Update(SerieResource entity)
        {
            throw new NotImplementedException();
        }
    }
}
