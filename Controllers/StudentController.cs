using Microsoft.AspNetCore.Mvc;
using UnitOfWorkCRUD.DTO_Model;
using UnitOfWorkCRUD.Models;
using UnitOfWorkCRUD.Repository;
using UnitOfWorkCRUD.Services;
using UnitOfWorkCRUD.UnitOfWork;

namespace UnitOfWorkCRUD.Controllers
{
    public class StudentController : Controller
    {

        // private readonly IRepository<Student> _studentRepository;

        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IStudentService studentService, IUnitOfWork unitOfWork)
        {
            _studentService = studentService;
            _unitOfWork= unitOfWork;

        }

        public IActionResult GetAllStudents()
        {
           IEnumerable<StudentDTO> studentsDTO= _studentService.GetAll();
            return View(studentsDTO);
        }

        //[HttpGet]
        //public IActionResult AddNewStudent()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddNewStudent(Student student)
        //{
        //    _studentRepository.Add(student);
        //    _unitOfWork.Commit();
        //    return Redirect("GetAllStudents");
        //}

        //[HttpGet]
        //public IActionResult EditStudent(int id)
        //{
        //    var student = _studentRepository.GetById(id);
        //    return View(student);
        //}

        //[HttpPost]
        //public IActionResult EditStudent(Student student)
        //{
        //  _studentRepository.Update(student);
        //    _unitOfWork.Commit();
        //    return Redirect("GetAllStudents");
        //}

        //public IActionResult DeleteStudent(int id)
        //{
        //    _studentRepository.Delete(id);
        //    _unitOfWork.Commit();
        //    return Redirect("GetAllStudents");
        //}

    }
}
