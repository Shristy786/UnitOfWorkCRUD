using Microsoft.AspNetCore.Mvc;
using UnitOfWorkCRUD.Models;
using UnitOfWorkCRUD.Repository;
using UnitOfWorkCRUD.UnitOfWork;

namespace UnitOfWorkCRUD.Controllers
{
    public class CourseController : Controller
    {

        private readonly IRepository<Course> _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IRepository<Course> courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult GetAllCourses()
        {
            IEnumerable<Course> courses= _courseRepository.GetAll();
            return View(courses);
        }


        [HttpGet]
        public IActionResult AddNewCourse()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddNewCourse(Course course)
        {
            _courseRepository.Add(course);
            _unitOfWork.Commit();
            return Redirect("GetAllCourses");

        }

        [HttpGet]
        public IActionResult EditCourse(int id) {

          Course course =  _courseRepository.GetById(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult EditCourse(Course course) {

            _courseRepository.Update(course);
            _unitOfWork.Commit();
            return Redirect("GetAllCourses");
        }

        public IActionResult DeleteCourse(int id)
        {
            _courseRepository.Delete(id);
            _unitOfWork.Commit();
            return Redirect("GetAllCourses");
        }

    }
}
