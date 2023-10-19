using AutoMapper;
using UnitOfWorkCRUD.DTO_Model;
using UnitOfWorkCRUD.Models;
using UnitOfWorkCRUD.Repository;

namespace UnitOfWorkCRUD.Services
{
    public class StudentService : Profile, IStudentService
    {

        private readonly IRepository<Student> _studentRepository;

        //Injecting the mapper object .
        private readonly IMapper _mapper;


        //Creating mapping profile for Mapping from one type to another.
        public StudentService()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
                
        }

        public StudentService(IRepository<Student>studentRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

      

        public IEnumerable<StudentDTO> GetAll()
        {

          IEnumerable<Student> students= _studentRepository.GetAll();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);//calling the map method that maps the students object to StudentDTO.
            
        }
    }
}
