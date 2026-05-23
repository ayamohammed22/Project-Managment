using Project_Managment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Infrastructure.Interfaces
{
    public interface IRepository<T>  where T : BaseEntitiy
    {
        Task<T?> GetByIdAsync(int id);

        IEnumerable<T> GetAll();

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
