using LMG.DAT.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.DAT.UnitOfWork
{
    public interface IGeneralUnitOfWork
    {
        Task<AuthorBookObject> GetAuthorBook();
    }

    public class AuthorBookObject
    {
        public string AuthorName { get; set; }
        public string BookName { get; set; }
    }
}
