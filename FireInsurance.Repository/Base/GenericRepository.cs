using FireInsurance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FireInsurance.Repository.Base
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private bool disposed = false;
        private readonly gtcir_tejarattalaieContext _db;
        private readonly DbSet<T> _entities;
        public GenericRepository(gtcir_tejarattalaieContext db)
        {
            _db = db;
            _entities = _db.Set<T>();
        }

        /// <summary>
        /// Add item to database table
        /// </summary>
        /// <param name="entity">The item</param>
        public async Task Create(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task CreateRange(List<T> entity)
        {
            try
            {
                await _entities.AddRangeAsync(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Get all items from database table
        /// </summary>
        public IEnumerable<T> Get()
        {
            return _entities.AsEnumerable();
        }

        /// <summary>
        /// Get all items from database table with expression
        /// </summary>
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _entities
                .Where(predicate)
                .AsEnumerable();
        }

        /// <summary>
        /// Get item from database table with row id
        /// </summary>
        /// <param name="id">Id of row</param>
        public async Task<T> GetById(object id)
        {
            return await _entities.FindAsync(id);
        }

        /// <summary>
        /// Remove item from database table
        /// </summary>
        /// <param name="entity">The item that you want to remove from database table</param>
        public async Task Remove(T entity)
        {
            try
            {
                _entities.Remove(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove item from database table
        /// </summary>
        /// <param name="id">The row id</param>
        public async Task Remove(object id)
        {
            try
            {
                T entity = await _entities.FindAsync(id);
                if (entity != null)
                {
                    _entities.Remove(entity);
                    await _db.SaveChangesAsync();
                }
                else
                    throw new ArgumentNullException("Can not find entity with id.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update item from database table
        /// </summary>
        /// <param name="entity">The item</param>
        public async Task Update(T entity)
        {
            _db.Entry<T>(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Update item from database table
        /// </summary>
        /// <param name="id">The row id</param>
        public async Task Update(object id)
        {
            try
            {
                T entity = await _entities.FindAsync(id);
                if (entity != null)
                {
                    _db.Entry<T>(entity).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                else
                    throw new ArgumentNullException("Can not find entity with id.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save edited data
        /// </summary>
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task RemoveRange(List<T> entity)
        {
            try
            {
                _entities.RemoveRange(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
