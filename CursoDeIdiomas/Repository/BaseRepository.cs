using CursoDeIdiomas.Data;
using CursoDeIdiomas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CursoDeIdiomasContext _context;
        public BaseRepository(CursoDeIdiomasContext context)
        {
            _context = context;
        }

        public async virtual Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

        }

        public virtual Task<IQueryable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public  virtual Task<T> GetByIdAsync(int id)
        {

            throw new NotImplementedException();

        }

        public virtual void Update(T entity)
        {
           _context.SaveChanges();
            
        }
    }
}
