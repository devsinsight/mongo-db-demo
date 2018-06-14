using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MongoDBDemo.Web.Repository;
using Newtonsoft.Json;
using System.IO;

namespace MongoDBDemo.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IFileRepository _fileRepository;

        public ValuesController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Hello World";

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("upload")]
        public void Upload()
        {
            var file = Request.Form.Files[0];

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                _fileRepository.Add(new Models.FileModel()
                {
                    File = fileBytes,
                    FileName = file.FileName,
                    Extension = file.FileName.Split(".")[1]
                });
                
            }


        }
    }
}
