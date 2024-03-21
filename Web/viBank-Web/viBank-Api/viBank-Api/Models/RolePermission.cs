using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Models
{
    public class RolePermission
    {
        public long ID { get; set; }
        public Guid RolesPermissionID { get; set; } = Guid.Empty;

        public long RoleID { get; set; }
        public long PermissionID { get; set; }

        public DateTime CreatedDTM { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDTM { get; set; } = null;

        public DateTime? DeletedDTM { get; set; } = null;

        [Timestamp]
        public virtual byte[]? RowVersion { get; set; }

        public Role Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}