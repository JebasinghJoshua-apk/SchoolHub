using Microsoft.EntityFrameworkCore;
using SchoolHub.Infrastructure;
using SchoolHub.Service.Interfaces;
using SchoolHub.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHub.Service.Services
{
    public class StudentService : IStudentService
    {
        public List<StudentViewModel> GetStudentListByClass(string className, string sectionName)
        {
            SchoolHubDBContext schoolHubDBContext = new SchoolHubDBContext();
            var studentList = schoolHubDBContext.Students.Include(x => x.Class)
                                               .Where(x => x.Class.ClassName == className
                                                      && x.Class.Section == sectionName);

            var studentViewList = studentList.Select(x => new StudentViewModel()
            {
                Name = x.Name,
                Age = x.Age,
                BloodGroup = x.BloodGroup,
                Gender = x.Gender,
                PhotoFilePath = x.PhotoFilePath,
            }).ToList();

            return studentViewList;
        }
    }
}