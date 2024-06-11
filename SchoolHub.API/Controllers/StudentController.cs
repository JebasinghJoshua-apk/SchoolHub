using Microsoft.AspNetCore.Mvc;
using SchoolHub.API.Model;
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
        public List<StudentModel> GetStudentListByClass(string className, string sectionName)
        {
            var studentList = new List<StudentModel>();

           
            return studentList;
        }
    }
}
