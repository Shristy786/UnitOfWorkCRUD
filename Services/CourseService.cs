using AutoMapper;
using UnitOfWorkCRUD.DTO_Model;
using UnitOfWorkCRUD.Models;
using UnitOfWorkCRUD.Repository;

namespace UnitOfWorkCRUD.Services
{
    public class CourseService : Profile, ICourseService
    {

        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;


        public CourseService()
        {
                CreateMap<Course,CourseDTO>().ReverseMap();
        }

        public CourseService(IRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public void CreateNewCourse(CourseDTO courseDTO)
        {
            Course course = _mapper.Map<Course>(courseDTO); 
            _courseRepository.Add(course);
        }

        public void DeleteCourse(int id)
        {
           _courseRepository.Delete(id);
        }

        public IEnumerable<CourseDTO> GetAllCourse()
        {
            IEnumerable<Course> courses=_courseRepository.GetAll();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public CourseDTO GetById(int id)
        {
            Course course = _courseRepository.GetById(id);
            return _mapper.Map<CourseDTO>(course);
        }

        public void UpdateCourse(CourseDTO courseDTO)
        {
            Course course = _mapper.Map<Course>(courseDTO);
            _courseRepository.Update(course);
        }
    }
}
