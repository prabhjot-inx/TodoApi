namespace TodoApi.Repositories;

public interface IRepository<T>
{
  Task<IEnumerable<T>> GetAll();
  Task<T> GetById(int ID);
  T Add(T entity);
  T Update(T entity);
  T Delete(T entity);
}


