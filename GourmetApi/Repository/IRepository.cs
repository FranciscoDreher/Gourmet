using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GourmetApi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id);
    }
}