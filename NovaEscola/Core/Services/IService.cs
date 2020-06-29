using NovaEscola.Controllers.Resources;
using NovaEscola.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NovaEscola.Core.Services
{
    public interface IService<IBaseEntity,IResource> where IBaseEntity : class where IResource : class
    {        
        public Task<IBaseEntity> Get(int id);
        public Task<IEnumerable<IBaseEntity>> GetAll();
        public Task<IBaseEntity> Create(IResource entity);

        public Task<IBaseEntity> Update(IResource entity);

        public Task<int> Delete(int id);
        
    }
}
