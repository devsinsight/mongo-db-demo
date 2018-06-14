using MongoDBDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBDemo.Web.Repository
{
    public interface IFileRepository
    {
        Task<FileModel> Get(string id);
        Task Add(FileModel file);
    }
}
