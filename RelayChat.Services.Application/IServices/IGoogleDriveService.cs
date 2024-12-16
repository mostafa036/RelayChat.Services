using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Application.IServices
{
    public interface IGoogleDriveService
    {
        Task<bool> UploadFileAsync(string fileName, string fileContent);
    }
}
