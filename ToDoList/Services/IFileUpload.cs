using System;
using System.Threading.Tasks;
using BlazorInputFile;

namespace ToDoList.Services
{
    public interface IFileUpload
    {
        Task Upload(IFileListEntry fileListEntity);
    }
}
