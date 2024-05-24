using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace viBank_Api.Helpers
{
    public class AuthenticatedUser
    {
        public long ID { get; set; }
        public string? Email { get; set; }
        public long? RoleID { get; set; }
        public string? UserName { get; set; }
        public long? AccountNumber { get; set; }
    }
    public enum UserRoles
    {
        Admin = 1001,
        User = 2001,
    }
    public static class AuthenticationHelper
    {
        public static async Task<AuthenticatedUser?> GetAuthenticatedUser(AppDbContext dbContext, ClaimsPrincipal user)
        {
            string? authenticatedUserEmail = user.FindFirstValue(ClaimTypes.Email);
            AuthenticatedUser? authenticatedUser = await dbContext.User
                                    .Select(u => new AuthenticatedUser
                                    {
                                        ID = u.ID,
                                        Email = u.Email,
                                        RoleID = u.RoleID,
                                        UserName = u.UserName,
                                        AccountNumber = u.Account!.AccountNumber
                                    })
                                    .FirstOrDefaultAsync(u => u.Email == authenticatedUserEmail);
            return authenticatedUser;
        }
        public static bool IsAdmin(long? roleId)
        {
            return roleId == (int)UserRoles.Admin;
        }
        public static bool IsUser(long? roleId)
        {
            return roleId == (int)UserRoles.User;
        }
    }
}
