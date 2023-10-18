namespace UnitOfWorkCRUD.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T entity);

        T GetById(int id);  

        void Update(T entity);  

        void Delete(int id);   
    }
}
