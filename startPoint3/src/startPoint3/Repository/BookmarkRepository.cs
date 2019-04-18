using MongoDB.Bson;
using MongoDB.Driver;
using startPoint3.Models.Bookmarks;
using System.Collections.Generic;

namespace startPoint3.Repository
{
    public class BookmarkRepository
    {
        MongoClient _client;
        IMongoDatabase _db;

        public BookmarkRepository(string userName)
        {
            _client = new MongoClient("mongodb://localhost");
            _db = _client.GetDatabase("Bookmarks_" + userName);
        }

        public void AddBookmarks(Bookmarks bookmarks)
        {
            _db.GetCollection<Bookmarks>("Bookmarks").InsertOne(bookmarks);
        }

        public Bookmarks GetBookmarks(string bucket)
        {
            return _db.GetCollection<Bookmarks>("Bookmarks").Find("{\"Bucket\":\"AAA\"}").FirstOrDefault();
        }

        public void UpdateBookmarks(Bookmarks bookmarks)
        {
            _db.GetCollection<Bookmarks>("Bookmarks").ReplaceOne("{\"Bucket\":\"AAA\"}", bookmarks, new UpdateOptions() { IsUpsert = true });
        }
    }
}


    