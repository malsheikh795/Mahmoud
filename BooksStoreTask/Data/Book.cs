using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Data
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
        public Category category { get; set; }
        public Author author { get; set; }

        [ForeignKey("category")]
        public int categoryId { get; set; }

        [ForeignKey("author")]
        public int authorId { get; set; }
    }
}
