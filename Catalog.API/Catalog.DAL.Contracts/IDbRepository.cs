using Catalog.DAL.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Contracts
{
    public interface IDbRepository
    {
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class;
        IQueryable<T> Get<T>() where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        Task<Guid> Add<T>(T newEntity) where T : class, IEntitry ;
        Task AddRange<T>(IEnumerable<T> newEntities) where T : class;

        Task Delete<T>(Guid entity) where T : class;

        Task Remove<T>(T entity) where T : class;
        Task RemoveRange<T>(IEnumerable<T> entities) where T : class;

        Task Update<T>(T entity) where T : class;
        Task UpdateRange<T>(IEnumerable<T> entities) where T : class;

        Task<int> SaveChangesAsync();
    }
}
