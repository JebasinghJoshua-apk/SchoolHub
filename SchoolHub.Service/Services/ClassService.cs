using SchoolHub.Core.Domain;
using SchoolHub.Infrastructure;
using SchoolHub.Service.Interfaces;
using SchoolHub.Service.ViewModel.Class;
using SchoolHub.Service.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHub.Service.Services
{
    public class ClassService : IClassService
    {
        public List<ClassViewModel> GetClasses()
        {
            var schoolHubDBContext = new SchoolHubDBContext();
            var classList = schoolHubDBContext.Classes.Select(x => new ClassViewModel()
            {
                ClassName = x.ClassName,
                Section = x.Section,
                ClassTeacherName = x.ClassTeacher.Name,
                EnglishTeacherName = x.EnglishTeacher.Name,
                MathsTeacherName = x.MathsTeacher.Name,
                ScienceTeacherName = x.ScienceTeacher.Name
            }).ToList();
            return classList;
        }

        public bool AddClass(AddClassViewModel addClassViewModel)
        {
            var schoolHubDBContext = new SchoolHubDBContext();
            //var classTeacher = schoolHubDBContext.Teachers.Where(x => x.Id == addClassViewModel.ClassTeacherId).First();
            //var englishTeacher = schoolHubDBContext.Teachers.Where(x => x.Id == addClassViewModel.EnglishTeacherId).First();
            //var mathsTeacher = schoolHubDBContext.Teachers.Where(x => x.Id == addClassViewModel.MathsTeacherId).First();
            //var scienceTeacher = schoolHubDBContext.Teachers.Where(x => x.Id == addClassViewModel.ScienceTeacherId).First();
            schoolHubDBContext.Classes.Add(new Class
            {
                ClassName = addClassViewModel.ClassName,
                Section = addClassViewModel.Section,
                ClassTeacherId = addClassViewModel.ClassTeacherId,
                EnglishTeacherId = addClassViewModel.EnglishTeacherId,
                MathsTeacherId = addClassViewModel.MathsTeacherId,
                ScienceTeacherId = addClassViewModel.ScienceTeacherId,
            });
            var result = schoolHubDBContext.SaveChanges();
            return (result > 0);
        }
    }
}
