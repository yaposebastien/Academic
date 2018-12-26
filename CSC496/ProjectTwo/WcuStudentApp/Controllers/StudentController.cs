using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WcuStudentApp.Models;

namespace WcuStudentApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

        //Passing Data from the controller
        public IActionResult ListOfStudents(string name, int num = 1) 
        {
            ViewData["Message"] = "Student name: " +name;
            ViewData["Num"] = num;

            return View();
        }
    }
}