using System;
using System.Collections.Generic;
using System.Linq;
using FloodChasersModel.Dao;
using MongoDB.Driver;

namespace FloodChasersLogic.Dao
{
    public class GenericDao<T> : IGenericDeo<T> where T : class
    {
        private readonly IMongoClient _client;
        private readonly IMongoCollection<T> _collection;

        public GenericDao(IMongoClient client)
        {
            _client = client;
            var database = _client.GetDatabase("FloodChasers");
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<T> GetAll()
        {
            return _collection.AsQueryable();
        }

        public T GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public T GetByField(string field, string value)
        {
            var filter = Builders<T>.Filter.Eq(field, value);
            return _collection.Find(filter).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdValue(entity));
            _collection.ReplaceOne(filter, entity);
        }

        public void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            _collection.DeleteOne(filter);
        }

        public void DeleteAll()
        {
            var filter = Builders<T>.Filter.Empty;
            _collection.DeleteMany(filter);
        }

        private string GetIdValue(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id"); 
            if (idProperty != null)
            {
                var idValue = idProperty.GetValue(entity)?.ToString();
                if (!string.IsNullOrEmpty(idValue))
                {
                    return idValue;
                }
            }

            throw new ArgumentException("Entity does not have a valid Id property.");
        }
    }
}
