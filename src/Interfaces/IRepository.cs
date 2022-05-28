namespace DIO_Series.src.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();
         T GetById(int id);
         void Add(T entity);
         void Delete(int id);
         void Update(int id, T entity);
         int NextId();
    }
}