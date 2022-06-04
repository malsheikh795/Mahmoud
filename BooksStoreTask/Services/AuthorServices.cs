using BooksStoreTask.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public class AuthorServices: IAuthorServices
    {
        BKContext context;
        Author athr;
        public AuthorServices(BKContext _context)
        {
            context = _context;
            athr = new Author();
        }
        public void Insert(Author athr)
        {
            context.authors.Add(athr);
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            athr=context.authors.Find(id);
            context.authors.Remove(athr);
            context.SaveChanges();
        }
        public void UpDate(Author a)
        {
            context.authors.Attach(a);
            context.Entry(a).State = EntityState.Modified;
            context.SaveChanges();
        }
        public List<Author> LoudAll()
        {
            List<Author> Li = context.authors.ToList();
            return Li;
        }
        public Author LoudEmpById(int id)
        {

            Author a = new Author();
            a = context.authors.Where(e => e.Id == id).First();
            return a;

        }
    }
}
