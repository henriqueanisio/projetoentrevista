using HenriqueAnisio.Data.Context;
using HenriqueAnisio.Domain.Interfaces;
using HenriqueAnisio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HenriqueAnisio.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly MyDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(MyDbContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) 
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<T> GetById(Guid Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<IEnumerable<T>> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = DbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }


        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task InsertAsync(T entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await Db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await Db.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
