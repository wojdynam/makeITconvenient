using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentModules.Interfaces
{
    public interface IRepository<T> where T : class
    {
         public Task<T> CreateAsync(T entity);
        public Task<T> ReadAsync(int id);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
        
    }
}
