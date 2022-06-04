using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Data
{
    [Table("Authors")]

    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public IFormFile AuthorPic { get; set; }
        public string PicPath { get; set; }
        public List<Book> LiBook { get; set; }

        [ForeignKey("nationality")]
        public int nationalityId { get; set; }

        public Nationality nationality { get; set; }



    }
}
