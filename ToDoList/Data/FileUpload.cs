using System;
using System.IO;
using System.Threading.Tasks;
using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using ToDoList.Services;

namespace ToDoList.Data
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _oWebHostEnvironment;

        public FileUpload(IWebHostEnvironment oWebHostEnvironment)
        {
            _oWebHostEnvironment = oWebHostEnvironment;
        }

        public async Task Upload(IFileListEntry fileList)
        {
            var path = Path.Combine(_oWebHostEnvironment.ContentRootPath, "UploadFiles", fileList.Name);



            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var memoryStream = new MemoryStream();

                await fileList.Data.CopyToAsync(memoryStream);
                memoryStream.WriteTo(file);
            }
        }
    }
}
