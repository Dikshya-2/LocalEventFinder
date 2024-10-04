namespace LocalEventFinder.Service.InterfaceForService
{
    public interface IGenericService<T> where T : class
    {
        T Create(T item);
        T GetById(int id);
        List<T> GetAll();
        T Update(int id, T item);
        void Delete(int id);
    }
}
