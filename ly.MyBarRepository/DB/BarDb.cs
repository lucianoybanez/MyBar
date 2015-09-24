using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ly.MyBarRepository.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ly.MyBarRepository.DB
{
    public class BarDb<T>
    {
        //restaurants

        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<T> _collection;

        private IMongoClient Client {
            get { return _client ?? (_client = new MongoClient()); }
        }

        private IMongoDatabase DataBase {
            get { return _database ?? (_database = Client.GetDatabase("test")); }
        }
        

        public BarDb()
        {
            _collection = DataBase.GetCollection<T>("restaurants");
        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> query)
        {
            return await _collection.Find<T>(query).ToListAsync();
        }


        public async void Insert()
        {
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "4230" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Argentina" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 11 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 17 }
                        }
                    }
                },
                { "name", "Vella" },
                { "restaurant_id", "41704620" }
            };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            await collection.InsertOneAsync(document);
        }

        public async Task<int> Get()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            //var filter = Builders<BsonDocument>.Filter.Eq({ },{ });
            var count = 0;
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // process document
                        count++;
                    }
                }
            }
            return count;
        }

        public async Task<int> GetFilter1()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan");
            var result = await collection.Find(filter).ToListAsync();
            return result.Count;
        }

        public IList<BsonDocument> GetFilter2()
        {
            var collection = DataBase.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("address.zipcode", "4230");
            var result =  collection.Find(filter).ToListAsync();
            return result.Result;
        }
      

        public async Task<int> GetGratherThan()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Gt("grades.score", 30);
            var result = await collection.Find(filter).ToListAsync();
            return result.Count;
        }
    }
}
