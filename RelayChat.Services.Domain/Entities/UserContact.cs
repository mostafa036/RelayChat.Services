using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Domain.Entities
{
    public class UserContact
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public int ContactId { get; set; }
        public ApplicationUser Contact { get; set; } = null!;
    }
}
