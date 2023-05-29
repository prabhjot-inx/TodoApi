namespace TodoApi.Repositories;

public interface IRepository<T>
{
  IEnumerable<T> GetAll();
  T GetById(int ID);
  T Add(T entity);
  T Update(T entity);
  T Delete(T entity);
}


