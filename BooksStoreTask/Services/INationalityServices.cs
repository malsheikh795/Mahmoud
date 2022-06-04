using BooksStoreTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Services
{
    public interface INationalityServices
    {
        List<Nationality> LoudAll();
        void Insert(Nationality obj);
        void UpDate(Nationality n);
        void Delete(int id);
    }
}
