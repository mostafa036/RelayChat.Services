using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace RelayChat.Services.Infrastructure.Services
{
    public class GoogleDriveService
    {
        private readonly DriveService _driveService;

        public GoogleDriveService(string credentialsPath)
        {
            GoogleCredential credential;
            
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
               
                credential = GoogleCredential.FromStream(stream).CreateScoped(DriveService.ScopeConstants.DriveFile);
            }
           
            _driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "RelayChat.Services" 
            });
        }

        public async Task<string> CreateFolderAsync(string folderName, string parentFolderId = null)
        {
            
            var folderMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
                Parents = parentFolderId != null ? new List<string> { parentFolderId } : null 
            };

            var request = _driveService.Files.Create(folderMetadata);
            request.Fields = "id";
           
            var folder = await request.ExecuteAsync();
            return folder.Id;
        }
        
        public async Task<Dictionary<string, string>> CreateUserFolderAndSubfoldersAsync(string userId, string mainFolderId)
        {
            
            var userFolderId = await CreateFolderAsync(userId, mainFolderId);
            var subfolderIds = new Dictionary<string, string>
        {
            { "UserFolder", userFolderId }
        };
            
            subfolderIds["Conversations"] = await CreateFolderAsync("Conversations", userFolderId);
            subfolderIds["Recordings"] = await CreateFolderAsync("Recordings", userFolderId);
            subfolderIds["Documents"] = await CreateFolderAsync("Documents", userFolderId);
            subfolderIds["Videos"] = await CreateFolderAsync("Videos", userFolderId);

            return subfolderIds; 
        }
















        //    public async Task UploadFilesToDrive()
        //    {
        //        string folderId = "19014fUHOuGq-jhKx9RP2iqnaYkjzWHg7";

        //        string credentialsPath = @"E:\Projects .NET\RelayChat.Services\RelayChat.Services.API\bin\Debug\net8.0\Credentials.json";

        //        string fileToUpload = @"E:\Projects .NET\RelayChat.Services\RelayChat.Services.API\wwwroot\Chatt\chatting.json";

        //        string directoryPath = Path.GetDirectoryName(credentialsPath);


        //        if (!Directory.Exists(directoryPath))
        //        {
        //            Directory.CreateDirectory(directoryPath);
        //        }

        //        GoogleCredential credential;
        //        try
        //        {
        //            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
        //            {
        //                credential = GoogleCredential.FromStream(stream).CreateScoped(new[] { DriveService.ScopeConstants.DriveFile });
        //            }

        //            if (credential == null)
        //            {
        //                throw new InvalidOperationException("GoogleCredential creation failed.");
        //            }

        //            var service = new DriveService(new BaseClientService.Initializer()
        //            {
        //                HttpClientInitializer = credential,
        //                ApplicationName = "RelayChat.Services"
        //            });


        //            string userId = Guid.NewGuid().ToString();
        //            await CreateUserFolderAndSubfolders(service, folderId, userId);  


        //            var fileMetaData = new Google.Apis.Drive.v3.Data.File()
        //            {
        //                Name = Path.GetFileName(fileToUpload),
        //                Parents = new List<string> { folderId }
        //            };

        //            FilesResource.CreateMediaUpload request;

        //            using (var streamFile = new FileStream(fileToUpload, FileMode.Open))
        //            {
        //                request = service.Files.Create(fileMetaData, streamFile, "application/octet-stream");
        //                request.Fields = "id";
        //                request.Upload();
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }
        //    }
        //    public async Task CreateUserFolderAndSubfolders(DriveService service, string parentFolderId, string userId)
        //    {
        //        // Create the user folder
        //        var userFolderId = await CreateFolderAsync(service, userId, parentFolderId);

        //        // Create subfolders inside the user folder
        //        await CreateFolderAsync(service, "Conversations", userFolderId);
        //        await CreateFolderAsync(service, "Recordings", userFolderId);
        //        await CreateFolderAsync(service, "Documents", userFolderId);
        //        await CreateFolderAsync(service, "Backups", userFolderId);
        //    }


        //    private string GetMimeType(string filePath)
        //    {

        //        var mimeType = "application/octet-stream";
        //        var extension = Path.GetExtension(filePath).ToLowerInvariant();

        //        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(extension);

        //        if (key != null && key.GetValue("Content Type") != null)
        //        {
        //            mimeType = key.GetValue("Content Type").ToString();
        //        }

        //        return mimeType;
        //    }

        //    public async Task<string> CreateFolderAsync(DriveService service, string folderName, string parentFolderId = null)
        //    {
        //        var folderMetadata = new Google.Apis.Drive.v3.Data.File()
        //        {
        //            Name = folderName,
        //            MimeType = "application/vnd.google-apps.folder",
        //            Parents = parentFolderId != null ? new[] { parentFolderId } : null
        //        };

        //        var request = service.Files.Create(folderMetadata);
        //        request.Fields = "id";

        //        var file = await request.ExecuteAsync();
        //        return file.Id;  
        //    }

    }
}

