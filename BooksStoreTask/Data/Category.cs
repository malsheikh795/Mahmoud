using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryCode { get; set; }
        public List<Book> LiB { get; set; }
    }
}
