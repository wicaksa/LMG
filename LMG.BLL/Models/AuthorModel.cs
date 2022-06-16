using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.BLL.Models
{
    public class AuthorModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Description { get; set; }

        public string Dob { get; set; } // Date of birth

        public string? Dod { get; set; } // Date of death
    }
}
