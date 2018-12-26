using System;
using System.ComponentModel.DataAnnotations;

namespace WcuStudentApp.Models
{
    //Defining our class Student
    public class Student 
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Major { get; set; }
    }
}