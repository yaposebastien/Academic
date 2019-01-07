using System;
using System.ComponentModel.DataAnnotations;

namespace WcuStudentApp.Models
{
    //Defining our class Student
    public class Student 
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        [Display(Name = "First  Name")]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [Required]
        public string Major { get; set; }
    }
}