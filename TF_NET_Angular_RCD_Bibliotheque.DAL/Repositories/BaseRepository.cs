using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        protected DbSet<TEntity> _entities;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity e)
        {
            TEntity newEntity = _entities.Add(e).Entity;
            _dbContext.SaveChanges();
            return newEntity;
        }
        public TEntity? GetOne(Func<TEntity, bool> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public List<TEntity> GetMany()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate)
        {
            return _entities.Where(predicate);
        }


        public bool Update(TEntity entity)
        {
            _entities.Update(entity);
            return _dbContext.SaveChanges() == 1;
        }
        public bool Delete(TEntity entity)
        {
            _entities.Remove(entity);
            return _dbContext.SaveChanges() == 1;
        }

    }
}
