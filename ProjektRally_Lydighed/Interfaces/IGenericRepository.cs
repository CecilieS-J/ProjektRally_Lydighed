namespace ProjektRally_Lydighed.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {

        public Task<T?> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
    }
}
