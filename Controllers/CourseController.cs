using Microsoft.AspNetCore.Mvc;
using UnitOfWorkCRUD.DTO_Model;
using UnitOfWorkCRUD.Models;
using UnitOfWorkCRUD.Repository;
using UnitOfWorkCRUD.Services;
using UnitOfWorkCRUD.UnitOfWork;

namespace UnitOfWorkCRUD.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseService _courseService;
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(ICourseService courseService, IUnitOfWork unitOfWork)
        {
            _courseService = courseService;
            _unitOfWork = unitOfWork;
        }
        public IActionResult GetAllCourses()
        {
            IEnumerable<CourseDTO> coursesDTO = _courseService.GetAllCourse(); 
            return View(coursesDTO);
        }


        [HttpGet]
        public IActionResult AddNewCourse()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddNewCourse(CourseDTO courseDTO)
        {
            _courseService.CreateNewCourse(courseDTO);
            _unitOfWork.Commit();
            return Redirect("GetAllCourses");

        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {

            CourseDTO courseDTO = _courseService.GetById(id);
            return View(courseDTO);
        }

        [HttpPost]
        public IActionResult EditCourse(CourseDTO courseDTO)
        {

            _courseService.UpdateCourse(courseDTO);
            _unitOfWork.Commit();
            return Redirect("GetAllCourses");
        }

        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);    
            _unitOfWork.Commit();
            return Redirect("GetAllCourses");
        }

    }
}
