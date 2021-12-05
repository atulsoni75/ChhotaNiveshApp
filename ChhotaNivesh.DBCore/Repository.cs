using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChhotaNivesh.DBCore
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DBContext _context;

        public Repository(DBContext context)
        {
            _context = context;
        }

        public async Task<T> Get(string id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(T).Name + " object is null");
            }
            _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();
            return obj;

        }

        public async Task<T> Delete(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Update(string id, T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
