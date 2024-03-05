using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using viBank_Api.Helpers;

namespace viBank_Api.Authorization
{
    public class RoleHandler
    {
        public static class ViBankAuthorizationPolicies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireUser = "RequireUser";
        }

        public class AdminRoleRequirement : IAuthorizationRequirement
        {

        }

        public class UserRoleRequirement : IAuthorizationRequirement
        {

        }
        public class RoleHandlers : IAuthorizationHandler
        {
            public readonly AppDbContext _dbContext;
            public RoleHandlers(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task HandleAsync(AuthorizationHandlerContext context)
            {
                var pendingRequirements = context.PendingRequirements.ToList();
                var currentUserEmail = context.User.FindFirstValue(ClaimTypes.Email);

                if (currentUserEmail == null)
                {
                    context.Fail();
                    return;
                }
                var roleId = await _dbContext.User.Where(u => u.Email == currentUserEmail)
                    .Select(u => u.RoleID).FirstOrDefaultAsync();

                foreach (var requirement in pendingRequirements)
                {
                    if (requirement is AdminRoleRequirement && AuthenticationHelper.IsAdmin(roleId))
                    {
                        context.Succeed(requirement);
                    }
                    if (requirement is UserRoleRequirement && AuthenticationHelper.IsCustomer(roleId))
                    {
                        context.Succeed(requirement);
                    }
                    if (requirement is UserRoleRequirement && AuthenticationHelper.IsEmployee(roleId))
                    {
                        context.Succeed(requirement);
                    }
                    if (requirement is UserRoleRequirement && AuthenticationHelper.IsPartner(roleId))
                    {
                        context.Succeed(requirement);
                    }
                }
            }
        }
    }
}