using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.Inventory.Repository.BaseClasses
{
    public class EntityFrameworkRepository<T> : IERepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        protected readonly DbSet<T> _dbSet;

        public EntityFrameworkRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Exception: " + ex.Message);
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Exception: " + ex.Message);
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Exception: " + ex.Message);
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                return Delete(entity);
            }
            return false;
        }

        public bool DeleteById(long id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                return Delete(entity);
            }
            return false;
        }

        public IEnumerable<T> GetPageData(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;
            try
            {
                return _dbSet.Skip(skip).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetPageData Exception: " + ex.Message);
                return new List<T>();
            }

        }

        public int RowCount()
        {
            return _dbSet.Count();
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
