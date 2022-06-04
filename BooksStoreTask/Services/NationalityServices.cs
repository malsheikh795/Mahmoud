using BooksStoreTask.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public class NationalityServices: INationalityServices
    {
        BKContext context;
        public NationalityServices(BKContext _context)
        {
            context = _context;
        }
        public List<Nationality> LoudAll()
        {
            
            List<Nationality> Li = context.nationalities.ToList();
            return Li;
        }
        public void Delete(int id)
        {
            Nationality n = new Nationality();
            n = context.nationalities.Find(id);
            context.nationalities.Remove(n);
            context.SaveChanges();
        }
        public void UpDate(Nationality n)
        {
            context.nationalities.Attach(n);
            context.Entry(n).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Insert(Nationality obj)
        {
            context.nationalities.Add(obj);
            context.SaveChanges();

        }
    }
}
