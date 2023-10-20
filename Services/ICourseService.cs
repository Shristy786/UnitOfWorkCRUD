using UnitOfWorkCRUD.DTO_Model;

namespace UnitOfWorkCRUD.Services
{
    public interface ICourseService
    {

        IEnumerable<CourseDTO> GetAllCourse();

        CourseDTO GetById(int id);

        void CreateNewCourse(CourseDTO courseDTO);

        void UpdateCourse(CourseDTO courseDTO);
        void DeleteCourse(int id);  

    }
}
