namespace LocalEventFinder.Repositories.Interface
{
    public interface IGeneric<T> where T : class
    {
        List<T> GetAll();
        T Create(T item); 
        T GetById(int id);
        T Update(int id, T item); 
        void Delete(int id);
    }
}
