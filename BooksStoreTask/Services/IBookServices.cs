using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public interface IBookServices
    {
        void Insert(Book obj);
        void Delete(int id);
        void UpDate(Book b);
        List<Book> LoudAll();
        Book LoudEmpById(int id);
    }
}
