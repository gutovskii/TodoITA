using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.DataAccess.Entities;

namespace TodoITA.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
    }
}
