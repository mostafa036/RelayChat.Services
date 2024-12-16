using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelayChat.Services.Infrastructure.Services;

namespace RelayChat.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackupController : ControllerBase
    {
 

        //[HttpPost("upload-chat")]
        //public  async Task<ActionResult> UploadChat()
        //{

        //    string fileToUpload = Path.Combine(_env.WebRootPath, "Chat", "Chatting.json");

        //    _uploadToDrive.UploadFilesToDrive(fileToUpload );

        //    return Ok("Chat file uploaded to Google Drive.");
        //}


        private readonly GoogleDriveService _googleDriveService;

        public BackupController()
        {
            string credentialsPath = @"E:\Projects .NET\RelayChat.Services\RelayChat.Services.API\bin\Debug\net8.0\Credentials.json";
            _googleDriveService = new GoogleDriveService(credentialsPath);
        }

        [HttpPost("create-user-folder")]
        public async Task<IActionResult> CreateUserFolders(string mainFolderId)
        {
            try
            {
                // Generate a unique user ID or accept as a parameter
                string userId = Guid.NewGuid().ToString();

                // Call the service function to create folders
                var userFolderId = await _googleDriveService.CreateUserFolderAndSubfoldersAsync(userId, mainFolderId);

                return Ok(new { UserFolderId = userFolderId, Message = "Folders created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Error creating folders: {ex.Message}" });
            }
        }



    }
}
