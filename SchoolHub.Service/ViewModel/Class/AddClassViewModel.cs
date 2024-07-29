using SchoolHub.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHub.Service.ViewModel.Class
{
    public class AddClassViewModel
    {
        public string ClassName { get; set; }
        public string Section { get; set; }
        public int ClassTeacherId { get; set; }
        public int EnglishTeacherId { get; set; }
        public int MathsTeacherId { get; set; }
        public int ScienceTeacherId { get; set; }
    }
}
