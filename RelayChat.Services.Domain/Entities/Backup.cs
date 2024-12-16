using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Domain.Entities
{
    public class Backup
    {
        public int BackupId { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public DateTime BackupDate { get; set; }
        public string UserFolderId { get; set; } = string.Empty;
        public long FileSize { get; set; }

        public string ConversationsId { get; set; } = string.Empty;
        public string RecordingsId { get; set; } = string.Empty;
        public string DocumentsId { get; set; } = string.Empty;
        public string VideosId { get; set; } = string.Empty;
    }
}
