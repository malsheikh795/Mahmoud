using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public interface IAuthorServices
    {
        void Insert(Author athr);
        public void Delete(int id);
        void UpDate(Author a);
        List<Author> LoudAll();
        Author LoudEmpById(int id);
    }
}
