using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Models
{
    public class vmNationality
    {
        public Nationality nationality { get; set; }
        public List<Nationality> LiN { get; set; }
    }
}
