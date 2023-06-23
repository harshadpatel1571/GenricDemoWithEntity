using Microsoft.EntityFrameworkCore;

namespace Demo.Service.Service;

public class GenericService<T> : IGenericService<T> where T : class
{
    protected readonly DemoContext _context;

    public GenericService(DemoContext context)
    {
        _context = context;
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task Update(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync().ConfigureAwait(false);
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
    }

    public async Task Remove(int id)
    {
        var data = await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        _context.Set<T>().Remove(data);
        await _context.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}
