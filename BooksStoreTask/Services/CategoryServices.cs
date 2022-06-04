using BooksStoreTask.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public class CategoryServices: ICategoryServices
    {
        BKContext context;
        public CategoryServices(BKContext _context)
        {
            context = _context;
        }
        public void Insert(Category obj)
        {
            context.categories.Add(obj);
            context.SaveChanges();

        }
        public List<Category> LoudAll()
        {
            List<Category> Li = context.categories.ToList();
            return Li;
        }
        public void Delete(int id)
        {
            Category c = new Category();
            c = context.categories.Find(id);
            context.categories.Remove(c);
            context.SaveChanges();
        }
        public void UpDate(Category c)
        {
            context.categories.Attach(c);
            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
        }
        public Category LoudEmpById(int id)
        {

            Category c = new Category();
            c = context.categories.Where(e => e.Id == id).First();
            return c;

        }
    }
}
