using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity e);
        public TEntity? GetOne(Func<TEntity, bool> predicate);
        public List<TEntity> GetMany();
        public IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate);
        public bool Update(TEntity entity);
        public bool Delete(TEntity entity);
    }
}
