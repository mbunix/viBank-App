
using System.ComponentModel.DataAnnotations;
namespace viBank_Api.Models
{
    public class UserModel
    {
        public long ID { get; set; }
        public Guid UserModelID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime? ResetDTMExpiry { get; set; }
        public string? ActivationToken { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public long RoleID { get; set; }
        public Account? Account { get; set; }
        public DateTime CreatedDTM { get; set; }
        public bool IsDeleted { get; set; } = false;
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDTM { get; set; }
        [Timestamp]
        public virtual byte[]? RowVersion { get; set; }
    }
}
