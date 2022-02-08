using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBookService.Models;

namespace SimpleBookService.Services
{
    public interface IBookService
    {
        List<Books> Get();
        Books Get(string id);
        Books Create(Books Books);
        void Update(string id, Books Books);
        void Remove(string id);
    }
}
