using BookshelfMVC.Application.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshelfMVC.Application.ViewModels.Books
{
    public class ListBookForListVm
    {
        public List<BookForListVm> Books { get; set; }
        public int Count { get; set; }
    }
}
