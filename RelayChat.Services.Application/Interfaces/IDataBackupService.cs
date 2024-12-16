using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Application.Interfaces
{
    public interface IDataBackupService
    {
        Task BackupDataAsync();

    }
}
