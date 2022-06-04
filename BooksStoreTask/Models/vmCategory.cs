using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Models
{
    public class vmCategory
    {
        public Category category { get; set; }
        public List<Category> LiC { get; set; }
    }
}
