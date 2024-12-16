using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Application.Interfaces
{
    public interface IBackupService
    {
        Task BackupDataAsync(int userId);
        Task RestoreDataAsync(int userId, string backupFilePath);
        Task ScheduleDailyBackupAsync(int userId); // Optional scheduling method
    }
}
