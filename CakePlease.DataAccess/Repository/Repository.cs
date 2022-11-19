using CakePlease.DataAccess.Repository.IRepository;
using CakePlease.DateAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CakePlease.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet <T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> quary = dbSet;
            return quary.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> quary = dbSet;
            quary = quary.Where(filter);
            return quary.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
