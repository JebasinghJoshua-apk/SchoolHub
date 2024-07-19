using Microsoft.AspNetCore.Mvc;
using SchoolHub.Service.Interfaces;
using SchoolHub.Service.Services;
using SchoolHub.Service.ViewModel.Student;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        readonly IStudentService _studentService;
        //constructor injection
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetStudentListByClass/{className}/{sectionName}")]
        public List<StudentViewModel> GetStudentListByClass(string className, string sectionName)
        {
            var studentList = _studentService.GetStudentListByClass(className, sectionName);
            return studentList;
        }

        [HttpPost]
        [Route("AddStudent")]
        public bool AddStudent(AddStudentViewModel addStudentViewModel)
        {
            var result = _studentService.AddStudent(addStudentViewModel);
            return result;
        }
        [HttpGet]
        [Route("GetClassList")]
        public List<string> GetClassList()
        {
            var classList = _studentService.GetClassList();
            return classList;
        }
        // GetSectionListByClass
    }
}
