﻿using Microsoft.EntityFrameworkCore;
using NovaEscola.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NovaEscola.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly NovaEscolaContext Context;
        protected readonly DbSet<TEntity> _entities;
        public Repository(NovaEscolaContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        
        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }
        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

    }
}
