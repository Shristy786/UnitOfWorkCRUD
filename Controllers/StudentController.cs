using Microsoft.AspNetCore.Mvc;
using UnitOfWorkCRUD.Models;
using UnitOfWorkCRUD.Repository;
using UnitOfWorkCRUD.UnitOfWork;

namespace UnitOfWorkCRUD.Controllers
{
    public class StudentController : Controller
    {

        private readonly IRepository<Student> _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IRepository<Student>studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork= unitOfWork;

        }

        public IActionResult GetAllStudents()
        {
            IEnumerable<Student> students = _studentRepository.GetAll();
            return View(students);
        }

        [HttpGet]
        public IActionResult AddNewStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewStudent(Student student)
        {
            _studentRepository.Add(student);
            _unitOfWork.Commit();
            return Redirect("GetAllStudents");
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = _studentRepository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
          _studentRepository.Update(student);
            _unitOfWork.Commit();
            return Redirect("GetAllStudents");
        }

        public IActionResult DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
            _unitOfWork.Commit();
            return Redirect("GetAllStudents");
        }

    }
}
