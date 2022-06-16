using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.BLL.Models
{
    public class ReviewModel
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public string? Review { get; set; }

    }
}
