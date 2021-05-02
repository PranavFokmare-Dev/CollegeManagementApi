using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IFileHandler
    {
        Task UploadFile(string fileName,string filepath, byte[] filecontent);
    }
    public class LocalFileHandler : IFileHandler
    {
        private readonly IWebHostEnvironment env;
        private readonly string rootpath;
        public LocalFileHandler(IWebHostEnvironment env)
        {
            this.env = env;
            rootpath = env.ContentRootPath;
        }
        public async Task UploadFile(string fileName,string filePath, byte[] filecontent)
        {
            
            if (!Directory.Exists(rootpath))
                throw new DirectoryNotFoundException();

            string FinalPath = rootpath + filePath + "/" + fileName;
            using (FileStream fs = new FileStream(FinalPath, FileMode.Create))
            {
                await fs.WriteAsync(filecontent, 0, filecontent.Length);
            }


        }
      
    }

}
