using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBDemo.Web.Models;

namespace MongoDBDemo.Web.Repository
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(new MongoClientSettings
            {
                Server = new MongoServerAddress(settings.Value.Host, settings.Value.Port),
                Credential = MongoCredential.CreateCredential(settings.Value.Database, settings.Value.Username, settings.Value.Password)
            });

            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<UnicornModel> Unicorns
        {
            get
            {
                return _database.GetCollection<UnicornModel>("unicorn");
            }
        }

        public IMongoCollection<FileModel> Files
        {
            get
            {
                return _database.GetCollection<FileModel>("files");
            }
        }
    }
}
