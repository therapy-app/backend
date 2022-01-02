using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace backend.Authorization
{
    public class ResourceAuthorizationHandler : AuthorizationHandler<SameTenantRequirement, Guid>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameTenantRequirement requirement,
                                                       Guid tenantId)
        {
            if (true)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
