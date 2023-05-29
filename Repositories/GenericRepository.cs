using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repositories;

public class GenericRepository<T> : IRepository<T> where T: class
{
  private readonly DbSet<T> _dbSet;
  public GenericRepository(TodoContext context)
  {
    _dbSet = context.Set<T>();
  }

  public IEnumerable<T> GetAll()
  {
    return _dbSet.ToList();
  }

  public T GetById(int ID) 
  {
    return _dbSet.Find(ID);
  }

  public T Add(T entiry)
  {
    _dbSet.Add(entiry);
    return entiry;
  }

  public T Update(T entiry)
  {
    _dbSet.Update(entiry);
    return entiry;
  }

  public T Delete(T entry)
  {
    _dbSet.Remove(entry);
    return entry;
  }
}