using Microsoft.EntityFrameworkCore;
using Project_Managment.Core.Entities;
using Project_Managment.Infrastructure.DataBase;
using Project_Managment.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Infrastructure.Repositiories
{
    public class GenericRepository<T> : IRepository<T>  where T : BaseEntitiy
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;

            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return  _dbSet.AsEnumerable();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
