using System;

namespace MongoDBDemo.Web.Models
{
    public class FileModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FileName { get; set; }
        public string Extension { get; set; }
        public byte[] File { get; set; }
    }
}
