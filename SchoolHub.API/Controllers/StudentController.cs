using Microsoft.AspNetCore.Mvc;
using SchoolHub.Service.Interfaces;
using SchoolHub.Service.Services;
using SchoolHub.Service.ViewModel;
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
    }
}
