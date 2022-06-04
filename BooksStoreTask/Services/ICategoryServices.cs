using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public interface ICategoryServices
    {
        void Insert(Category obj);
        List<Category> LoudAll();
        void Delete(int id);
        void UpDate(Category c);
        Category LoudEmpById(int id);
    }
}
