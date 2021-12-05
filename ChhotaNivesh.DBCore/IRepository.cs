using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChhotaNivesh.DBCore
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(string id);

        // add new entity
        Task<T> Create(T item);

        // remove a single entity
        Task<T> Delete(string id);

        // update just a single entity
        Task<bool> Update(string id, T obj);

      
    }
}
