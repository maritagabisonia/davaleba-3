using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dav33.Models
{
    [Table("MATI_STUDENTS")]
    public class Student
    {
        public int Id { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}