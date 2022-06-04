using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Models
{
    public class vmBook
    {
        public Book book { get; set; }
        public List<Book> LiB { get; set; }
        public List<Author> LiA { get; set; }
        public List<Category> LiC { get; set; }

    }
}
