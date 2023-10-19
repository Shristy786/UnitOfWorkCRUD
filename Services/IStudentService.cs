using UnitOfWorkCRUD.DTO_Model;

namespace UnitOfWorkCRUD.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAll();
    }
}
