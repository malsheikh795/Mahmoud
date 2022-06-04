using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Data
{
    [Table("Nationalities")]
    public class Nationality
    {
        public int Id { get; set; }
        [Required]
        public string NationalityName { get; set; }
        public List<Author> LiAuthors { get; set; }

    }
}
