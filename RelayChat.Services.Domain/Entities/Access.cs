using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Domain.Entities
{
    public class Access
    {
        public int AccessId { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public DateTime AccessTime { get; set; } 
        public string AccessType { get; set; } = string.Empty; 
        public string IpAddress { get; set; } = string.Empty;  
        public string Location { get; set; } = string.Empty;  
        public string Browser { get; set; } = string.Empty;  
        public bool IsSuccessful { get; set; } 
    }
}
