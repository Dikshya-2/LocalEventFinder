using LocalEventFinder.Service.InterfaceForService;

namespace LocalEventFinder.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericService<T> _service;

        public GenericService(IGenericService<T> service)
        {
            _service = service;
        }
        public T Create(T item)
        {
            return _service.Create(item);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<T> GetAll()
        {
            return _service.GetAll();
        }

        public T GetById(int id)
        {
           return _service.GetById(id);
        }

        public T Update(int id, T item)
        {
            return _service.Update(id, item);
        }
    }
}
