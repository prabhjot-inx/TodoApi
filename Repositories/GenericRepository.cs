using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repositories;

public class GenericRepository<T> : IRepository<T> where T: class
{
  private readonly DbSet<T> _dbSet;
  private readonly TodoContext _context;
  public GenericRepository(TodoContext context)
  {
    _dbSet = context.Set<T>();
    _context = context;

  }

  public async Task<IEnumerable<T>> GetAll()
  {
    return await _dbSet.ToListAsync();
  }

  public async Task<T> GetById(int ID) 
  {
    return await _dbSet.FindAsync(ID);
  }

  public T Add(T entiry)
  {
    _dbSet.Add(entiry);
    _context.SaveChanges();
    return entiry;
  }

  public T Update(T entiry)
  {
    _dbSet.Update(entiry);
    _context.SaveChanges();
    return entiry;
  }

  public T Delete(T entry)
  {
    _dbSet.Remove(entry);
    _context.SaveChanges();
    return entry;
  }
}