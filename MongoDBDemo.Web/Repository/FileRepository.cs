using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDBDemo.Web.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDBDemo.Web.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly MongoDBContext _context = null;

        public FileRepository(IOptions<MongoDBSettings> settings)
        {
            _context = new MongoDBContext(settings);
        }

        public async Task Add(FileModel file)
        {
            await _context.Files.InsertOneAsync(file);
        }

        public async Task<FileModel> Get(string id)
        {
            var filter = Builders<FileModel>.Filter.Eq("Id", id);

             return await _context.Files
                                .Find(filter)
                                .FirstOrDefaultAsync();

        }
    }
}
