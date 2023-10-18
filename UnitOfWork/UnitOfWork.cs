using UnitOfWorkCRUD.Data;

namespace UnitOfWorkCRUD.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly StudentDBContext _studentDbContext;
        public UnitOfWork(StudentDBContext studentDbContext)
        {
           _studentDbContext=studentDbContext;  
        }
        public void Commit()
        {
         
            _studentDbContext.SaveChanges();    
             
        }
    }
}
