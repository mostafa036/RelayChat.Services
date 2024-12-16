using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Domain.Entities
{
    public class BlockListUser
    {
        public int BlockListUserId { get; set; }

        public DateTime BlockedAt { get; set; }  
        public string Reason { get; set; } = string.Empty;
        public bool IsPermanent { get; set; } // Indicates if the block is permanent or temporary
        public DateTime? UnblockedAt { get; set; }

        public int BlockingUserId { get; set; }
        public ApplicationUser BlockingUser { get; set; } = null!;

        public int BlockedUserId { get; set; } 
        public ApplicationUser BlockedUser { get; set; } = null!;
    }
}
