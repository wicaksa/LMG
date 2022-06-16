using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.BLL.Models
{
    public class MemberModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Birthdate { get; set; } = null!;
        public string? Gender { get; set; }
        public long Phone { get; set; }
    }
}
