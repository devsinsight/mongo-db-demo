using MongoDBDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBDemo.Web.Repository
{
    public interface IUnicornRepository
    {

        Task<IEnumerable<UnicornModel>> GetAll();
        Task<UnicornModel> Get(string id);
        Task Add(UnicornModel item);
        Task<bool> Remove(string id);
        Task<bool> UpdateUnicornName(string id, string name);
        Task<bool> UpdateUnicorn(string id, UnicornModel unicorn);
        Task<bool> RemoveAll();

    }
}
