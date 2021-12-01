using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Infraestructure.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<bool> Add(T entity);
        Task<bool> Remove(T entity);
        Task<bool> Update(T entity);
        Task<IEnumerable<T>> Get();
        Task<T> GetOne(string Id);
    }
}
