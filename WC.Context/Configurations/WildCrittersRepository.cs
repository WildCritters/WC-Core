using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WC.Context.Configurations
{
    public class WildCrittersRepository<TEntity> where TEntity : class
    {
        internal WildCrittersDBContext Context { get; set; }

        internal DbSet<TEntity> DbSet { get; set; }

        public WildCrittersRepository(WildCrittersDBContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetEnumerable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {

            IQueryable<TEntity> query = DbSet;

            if (filter != null) query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
            StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            DbSet.Attach(entityToUpdate);
        }
    }
}
