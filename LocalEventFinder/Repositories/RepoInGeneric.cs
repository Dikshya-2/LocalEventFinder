
using LocalEventFinder.Model;
using LocalEventFinder.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LocalEventFinder.Repositories
{
    public class RepoInGeneric<T> : IGeneric<T> where T : class
    {
        private readonly DatabaseContext _context;

        public RepoInGeneric(DatabaseContext context)
        {
            _context = context;
        }
        public T Create(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            T data = _context.Set<T>().Find(id);
            if (data != null)
            {
                _context.Set<T>().Remove(data);
                _context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        public T GetById(int id)
        {
            return _context.Set<T>().Find(id) as T;
        }

        public T Update(int id, T item)
        {
            var existingItem = _context.Set<T>().Find(id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return existingItem;
            }
            return null; 
        }
    }


}
