using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Domain.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }

        public string DeviceType { get; set; } = string.Empty; 
        public string DeviceName { get; set; } = string.Empty;   
        public string DeviceOS { get; set; } = string.Empty; 
        public string DeviceToken { get; set; } = string.Empty; 

        public DateTime LastAccessed { get; set; } 
        public string DeviceModel { get; set; } = string.Empty; 
        public bool IsPrimary { get; set; }
        public string Manufacturer { get; set; } = string.Empty;

        public string ApplicationUserId { get; set; } = string.Empty;  
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }

}
