using Microsoft.EntityFrameworkCore;
using SchoolHub.Core.Domain;
using SchoolHub.Infrastructure;
using SchoolHub.Service.Interfaces;
using SchoolHub.Service.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                Age = DateTime.Today.Year - x.DateOfBirth.Year,
                BloodGroup = x.BloodGroup,
                Gender = x.Gender,
                PhotoFilePath = x.PhotoFilePath,
            }).ToList();

            return studentViewList;
        }

        public List<string> GetClassList()
        {
            var schoolHubDBContext = new SchoolHubDBContext();
            var classList = schoolHubDBContext.Classes.Select(x=> x.ClassName).ToList();
            return classList;
        }
        public List<string> GetSectionListByClass(string className)
        {
            var schoolHubDBContext = new SchoolHubDBContext();
            var sectionList = schoolHubDBContext.Classes.Where(x=>x.ClassName==className).Select(x => x.Section).ToList();
            return sectionList;
        }
        public bool AddStudent(AddStudentViewModel addStudentViewModel)
        {
            var schoolHubDBContext = new SchoolHubDBContext();
            var classobj = schoolHubDBContext.Classes.FirstOrDefault(x => x.ClassName == addStudentViewModel.ClassStandard && x.Section == addStudentViewModel.ClassSection);
            var classStudentCount = schoolHubDBContext.Students.Count(x => x.ClassId == classobj.Id);
            schoolHubDBContext.Students.Add(new Student
            {
                RollNumber = Convert.ToString(classStudentCount + 1),
                Name = addStudentViewModel.StudentName,
                DateOfBirth = addStudentViewModel.DateOfBirth,
                Gender = addStudentViewModel.Gender,
                FatherName = addStudentViewModel.FatherName,
                MotherName = addStudentViewModel.MotherName,
                ContactNumber1 = addStudentViewModel.ContactNumber1,
                ContactNumber2 = addStudentViewModel.ContactNumber2,
                BloodGroup = addStudentViewModel.BloodGroup,
                Class = classobj,
            });
            var result = schoolHubDBContext.SaveChanges();
            return (result > 0);
        }
    }
}