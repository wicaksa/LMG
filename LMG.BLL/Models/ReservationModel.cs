using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.BLL.Models
{
    public class ReservationModel
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReservationDate { get; set; }

        public DateTime ReservationExpirationDate { get; set; }

        public Boolean ReservationStatus { get; set; } // True =It's still live, False = Not live

        public String? ReservationResult { get; set; } // Borrow, Cancel, or Expired
    }
}
