using UnitOfWorkCRUD.DTO_Model;

namespace UnitOfWorkCRUD.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAll();

        void AddNewStudent(StudentDTO studentDTO);

        StudentDTO GetById(int id);

        void UpdateStudent(StudentDTO studentDTO);

        void DeleteStudent(int id); 


    }
}
