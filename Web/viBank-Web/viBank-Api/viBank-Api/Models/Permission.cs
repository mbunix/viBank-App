using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Models
{
    public class Permission
    {
        public long ID { get; set; }
        public Guid PermissionID { get; set; } = Guid.Empty;
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;
        public DateTime CreatedDTM { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDTM { get; set; } = null;
        public DateTime? DeletedDTM { get; set; } = null;
        [Timestamp]
        public virtual byte[]? RowVersion { get; set; }
        public ICollection<RolePermission> RolePermissions { get; } = new List<RolePermission>();
        public ICollection<Role> Roles { get; } = new List<Role>();
    }
}