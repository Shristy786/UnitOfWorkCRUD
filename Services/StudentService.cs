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

        public void AddNewStudent(StudentDTO studentDTO)
        {
            Student student= _mapper.Map<Student>(studentDTO);
            _studentRepository.Add(student);
        }

        public void DeleteStudent(int id)
        {
           _studentRepository.Delete(id);
        }

        public IEnumerable<StudentDTO> GetAll()
        {

          IEnumerable<Student> students= _studentRepository.GetAll();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);//calling the map method that maps the students object to StudentDTO.
            
        }

        public StudentDTO GetById(int id)
        {
            
            Student student=_studentRepository.GetById(id);
            return _mapper.Map<StudentDTO>(student);


        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            Student student = _mapper.Map<Student>(studentDTO);
            _studentRepository.Update(student);
        }
    }
}
