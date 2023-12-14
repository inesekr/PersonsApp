using PersonsApp.Core.Models;
using PersonsApp.Core.Services;
using PersonsApp.Data;

namespace PersonsApp.Services
{
   public class DbService : IDbService
    {
        protected readonly PersonDbContext _context;
        public DbService(PersonDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Where(e => e.Id == id).AsQueryable();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public void Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Exists<T>(int id) where T : Entity
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }
    }
}
