using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    public class BooksController : ApiController
    {
        static readonly MongoClient MongoClient = new MongoClient("mongodb://localhost:27017");
        private readonly IMongoCollection<Book> _books;

        public BooksController()
        {
            var db = MongoClient.GetDatabase("myCollections");
            _books = db.GetCollection<Book>("books");
        }

        // GET: api/books
        public async Task<List<Book>> Get()
        {
            var filter = Builders<Book>.Filter.Empty;
            return await _books.Find(filter).ToListAsync();
        }

        // GET: api/books/5
        public async Task<Book> Get(string id)
        {
            var filter = Builders<Book>.Filter.Eq("Id", id);
            return await _books.Find(filter).FirstAsync();
        }

        // POST: api/books
        public async Task Post([FromBody]Book book)
        {
            await _books.InsertOneAsync(book);
        }

        // PUT: api/books/5
        public async Task Put(string id, [FromBody]Book book)
        {
            var filter = Builders<Book>.Filter.Eq("Id", id);
            var update = Builders<Book>.Update
                .Set(b => b.Title, book.Title)
                .Set(b => b.Author, book.Author)
                .Set(b => b.CompletionDate, book.CompletionDate)
                .Set(b => b.Mode, book.Mode);
            await _books.UpdateOneAsync(filter, update);
        }

        // DELETE: api/books/5
        public async Task Delete(string id)
        {
            var filter = Builders<Book>.Filter.Eq("Id", id);
            await _books.DeleteOneAsync(filter);
        }

    }
}
