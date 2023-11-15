using LibraryProject.Domain.Entities;

namespace LibraryProject.Domain.Interfaces
{
    public interface IBaseRepository<T> 
        where T : BaseEntity
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
        T? Get(int id);
        Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);

    }
}
