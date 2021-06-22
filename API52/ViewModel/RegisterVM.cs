using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.ViewModel
{
    public enum GenderRole
    {
        Pria = 1, Wanita = 2
    }
    public class RegisterVM
    {
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderRole Gender { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }
    }
}
