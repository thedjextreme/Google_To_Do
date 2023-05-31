using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Google_To_Do.Models
{
    public class zadanie
    {
        [Key]
        public int Id { get; set; }

        //public string LoginId { get; set; }
        //public string Pasword { get; set; }

        public string TaskName { get; set; }



        public string description { get; set; }

        public string priority { get; set; }
        public bool IsActive { get; set; } = true;

        //public int PriorityID { get; set; }
        //public Priority Priority { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{YYYY-MM-DD HH:mm}"/*, ApplyFormatInEditMode = true*/)]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }
        public int CategoryId { get; set; }



        //logowanie
        //public int Idl { get; set; }
        //public string LoginId { get; set; }
        //public string Password { get; set; }
        //public string EmpoyeeName { get; set; }
        //public string LoginId { get; set; }
        //public string Pasword { get; set; }
    }


}
