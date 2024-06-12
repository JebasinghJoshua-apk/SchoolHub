using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Route("GetStudentListByClass/{className}/{sectionName}")]
        public List<StudentViewModel> GetStudentListByClass(string className, string sectionName)
        {
            StudentService studentService = new StudentService();
            var studentList = studentService.GetStudentListByClass(className, sectionName);
            return studentList;
        }
    }
}
