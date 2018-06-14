using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDBDemo.Web.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDBDemo.Web.Repository
{
    public class UnicornRepository : IUnicornRepository
    {

        private readonly MongoDBContext _context = null;

        public UnicornRepository(IOptions<MongoDBSettings> settings)
        {
            _context = new MongoDBContext(settings);
        }

        public async Task<IEnumerable<UnicornModel>> GetAll()
        {
            try
            {
                return await _context.Unicorns
                        .Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<UnicornModel> Get(string id)
        {
            var filter = Builders<UnicornModel>.Filter.Eq("Id", id);

            try
            {
                return await _context.Unicorns
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task Add(UnicornModel item)
        {
            try
            {
                await _context.Unicorns.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Unicorns.DeleteOneAsync(
                        Builders<UnicornModel>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateUnicornName(string id, string name)
        {
            var filter = Builders<UnicornModel>.Filter.Eq(s => s.Id, id);
            var update = Builders<UnicornModel>.Update
                            .Set(s => s.Name, name)
                            .CurrentDate(s => s.UpdatedOn);

            try
            {
                UpdateResult actionResult
                     = await _context.Unicorns.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateUnicorn(string id, UnicornModel item)
        {
            try
            {
                ReplaceOneResult actionResult
                    = await _context.Unicorns
                                    .ReplaceOneAsync(n => n.Id.Equals(id)
                                            , item
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAll()
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Unicorns.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
