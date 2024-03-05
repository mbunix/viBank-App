using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace viBank_Api.Models
{
        public class UserModel
        {
                public long ID { get; set; }
                public Guid UserID { get; set; }
                public string UserName { get; set; } = string.Empty;
                public string PasswordHash { get; set; } = string.Empty;
                public string Email { get; set; } = string.Empty;
                public string? RefreshToken { get; set; }
                public string? ResetToken { get; set; }
                public DateTime? RefreshTokenExpiryTime { get; set; }
#nullable enable
                public DateTime? ResetDTMExpiry { get; set; }
#nullable enable
                public string? ActivationToken { get; set; }
#nullable enable
                public DateTime? ActivationDate { get; set; }
#nullable enable
                public DateTime? UpdatedDTM { get; set; }
                public long RoleID { get; set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                public DateTime CreatedDTM { get; set; }
                public bool IsDeleted { get; set; }
                public long? DeletedBy { get; set; }
                public DateTime? DeletedDTM { get; set; }
                [Timestamp]
                public virtual byte[]? RowVersion { get; set; }
        }
}
