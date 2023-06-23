using System.Linq.Expressions;

namespace Demo.Service.Abstraction;

public interface IGenericService<T> where T : class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    Task Add(T entity);
    Task Update(T entity);
    void AddRange(IEnumerable<T> entities);
    Task Remove(int id);
    void RemoveRange(IEnumerable<T> entities);
}
