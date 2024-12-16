using Microsoft.AspNetCore.Identity;

namespace RelayChat.Services.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string UserDisplay { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string ProfilePictureName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;          
        public string Timezone { get; set; } = string.Empty;               
        public string Language { get; set; } = string.Empty;
        public string? bio { get; set; } 

        public DateTime DateJoined { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public DateTime LastTimeActive { get; set; }

        public Backup Backup { get; set; } = null!;
        public Device Device { get; set; } = null!;

        public ICollection<Groups> Groups { get; set; } = new HashSet<Groups>();
        public ICollection<UserContact> Contacts { get; set; } = new HashSet<UserContact>(); 
        public ICollection<UserContact> RelatedContacts { get; set; } = new HashSet<UserContact>();
    }
}
