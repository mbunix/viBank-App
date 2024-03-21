using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Models
{
    public class Role
    {
        public long ID { get; set; }
        public Guid RoleID { get; set; } = Guid.Empty;
        public string Name { get; set; } = String.Empty;
        public DateTime CreatedDTM { get; set; } = DateTime.Now;
        public DateTime? UpdatedDTM { get; set; }
        public DateTime? DeletedDTM { get; set; }
        [Timestamp]
        public virtual byte[]? RowVersion { get; set; }
        public UserModel? User { get; set; }
        public ICollection<RolePermission> RolePermissions { get; } = new List<RolePermission>();
        public ICollection<Permission> Permissions { get; } = new List<Permission>();
    }
}