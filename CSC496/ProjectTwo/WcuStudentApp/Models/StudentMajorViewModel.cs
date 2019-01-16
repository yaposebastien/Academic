using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WcuStudentApp.Models
{
    public class StudentMajorViewModel 
    {
        public List<Student> Students;
        public SelectList Majors;
        public string StudentMajor { get; set;}
        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }
    }
}