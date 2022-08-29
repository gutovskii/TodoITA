using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TodoITA.DataAccess.Entities;
using TodoITA.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TodoITA.DataAccess.Repositories.Realizations
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly TodoDbContext _db;
        public BaseRepository(TodoDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);

            if (entity == null) return false;

            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
