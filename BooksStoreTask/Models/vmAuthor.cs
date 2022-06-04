using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Models
{
    public class vmAuthor
    {
        public Author author { get; set; }
        public List<Author> LiA { get; set; }
        public List<Nationality> LiN { get; set; }
    }
}
