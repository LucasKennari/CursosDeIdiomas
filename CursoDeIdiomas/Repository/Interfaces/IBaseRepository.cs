namespace CursoDeIdiomas.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        public Task<T> AddAsync(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        //  public Task LogicDeleteAsync(Guid id);
    }
}
