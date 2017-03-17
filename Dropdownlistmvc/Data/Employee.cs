using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dropdownlistmvc.Data
{
    public class Employee
    {
        public int  Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public  string LastName { get; set; }
        [Required]
        [DisplayName("Gender")]
        public int GenderId { get; set; }
        [Required]
        [DisplayName("Salary")]
        public int Salary { get; set; }
        //TO get Name Details
        public virtual Gender Genders { get; set; }
        //To use it with DropDownList Fill
        public virtual IEnumerable<Gender> GendersEnum { get; set; }
    }
}