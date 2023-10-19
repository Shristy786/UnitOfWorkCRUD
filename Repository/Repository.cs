using Microsoft.EntityFrameworkCore;
using UnitOfWorkCRUD.Data;
using UnitOfWorkCRUD.UnitOfWork;

namespace UnitOfWorkCRUD.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly StudentDBContext _studentDBContext;
        private readonly DbSet<T> _dbSet;  

        public Repository(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
            _dbSet = _studentDBContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            var students = _dbSet.ToList();
            return students;

        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);

            
        }

       

        public T GetById(int id)
        {
         T entity = _dbSet.Find(id);
            return entity;

        }

        public void Update(T entity)
        {
           _dbSet.Attach(entity);
            _dbSet.Entry(entity).State= EntityState.Modified;   

        }

        public void Delete(int id)
        {
            T entity=_dbSet.Find(id);
            _dbSet.Remove(entity);

        }
    }
}
