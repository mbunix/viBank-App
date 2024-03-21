using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Models
{
    public class Partner
    {
        public long ID { get; set; }
        public string NameSuffix { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string Surname { get; set; } = string.Empty;
        public UserModel User { get; set; } = new UserModel();
        public DateTime CreatedDTM { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public Boolean IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDTM { get; set; }
        public long RoleID { get; set; }
        public Role? Role { get; set; }

    }
}