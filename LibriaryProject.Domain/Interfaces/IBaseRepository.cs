using LibraryProject.Domain.Entities;

namespace LibraryProject.Domain.Interfaces
{
    public interface IBaseRepository<T> 
        where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<bool> Delete(T entity);
        Task<T?> Get(int id);
        Task<bool> Update(T entity);

    }
}
