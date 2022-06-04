using BooksStoreTask.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public class BookServices: IBookServices
    {
        BKContext context;
        public BookServices(BKContext _context)
        {
            context = _context;
        }
        public void Insert(Book obj)
        {
            context.books.Add(obj);
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            Book bk = context.books.Find(id);
            context.books.Remove(bk);
            context.SaveChanges();
        }
        public void UpDate(Book b)
        {
            context.books.Attach(b);
            context.Entry(b).State = EntityState.Modified;
            context.SaveChanges();
        }
        public List<Book> LoudAll()
        {
            return context.books.Include("category").Include("author").ToList();
            
        }
        public Book LoudEmpById(int id)
        {

            Book b = new Book();
            b = context.books.Where(e => e.Id == id).First();
            return b;

        }
    }
}
