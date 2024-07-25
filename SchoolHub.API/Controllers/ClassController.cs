using Microsoft.AspNetCore.Mvc;
using SchoolHub.Service.Services;
using SchoolHub.Service.ViewModel.Class;
using System.Collections.Generic;

namespace SchoolHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("GetClasses")]
        public List<ClassViewModel> GetClasses()
        { 
            ClassService obj = new ClassService();
            return obj.GetClasses();
        }
    }
}
