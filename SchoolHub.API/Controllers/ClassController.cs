using Microsoft.AspNetCore.Mvc;
using SchoolHub.Service.Interfaces;
using SchoolHub.Service.Services;
using SchoolHub.Service.ViewModel.Class;
using SchoolHub.Service.ViewModel.Student;
using SchoolHub.Service.ViewModel.Teacher;
using System.Collections.Generic;

namespace SchoolHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : Controller
    {
        readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
 
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("GetClasses")]
        public List<ClassViewModel> GetClasses()
        {
            var classes = _classService.GetClasses();
            return classes;
        }

        [HttpPost]
        [Route("AddClass")]
        public bool AddClass(AddClassViewModel addClassViewModel)
        {
            var result = _classService.AddClass(addClassViewModel);
            return result;
        }

        [HttpGet]
        [Route("GetTeacherList")]
        public List<SelectTeacherViewModel> GetTeacherList()
        {
            var teacherList = _classService.GetTeacherList();
            return teacherList;
        }
    }
}
