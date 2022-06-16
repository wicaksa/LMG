using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.BLL.Models
{
    public class BookModel
    {
        public string Title { get; set; }

        public int Copies { get; set; }

        public int? SerieId { get; set; }

        public int Edition { get; set; }

        public string? Genre { get; set; }

        public string? Summary { get; set; }

        public int PublicationYear { get; set; }
    }
}
