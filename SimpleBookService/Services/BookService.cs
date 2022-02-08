using SimpleBookService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SimpleBookService.Services
  
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Books> BookCol;
        public BookService(IBookStoreDb settings, IMongoClient mongoClient)
        {
            var dataabase = mongoClient.GetDatabase(settings.DatabaseName);
            BookCol = dataabase.GetCollection<Books>(settings.BookStoreCollectionName);
        }
        public Books Create(Books books)
        {
            books.TimeStamp = DateTime.Now.ToString();
            BookCol.InsertOne(books);
            return books;
        }

        public List<Books> Get()
        {
            return BookCol.Find(book => true).ToList();
        }

        public Books Get(string id)
        {
           
            return BookCol.Find(book => book.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            BookCol.DeleteOne(book => book.Id ==id);
        }

        public void Update(string id, Books books)
        {
            books.TimeStamp = DateTime.Now.ToString();
            BookCol.ReplaceOne(book => book.Id == id, books);
        }
    }
}
