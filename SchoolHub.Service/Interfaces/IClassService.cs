using SchoolHub.Service.ViewModel.Class;
using SchoolHub.Service.ViewModel.Teacher;

namespace SchoolHub.Service.Interfaces
{
    public interface IClassService
    {
        List<ClassViewModel> GetClasses();

        bool AddClass(AddClassViewModel addClassViewModel);
        List<SelectTeacherViewModel> GetTeacherList();
    }
}
