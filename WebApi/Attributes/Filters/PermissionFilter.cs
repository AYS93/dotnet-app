using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Enums;

namespace WebApi.Attributes.Filters
{
    public class PermissionFilter : IAuthorizationFilter
    {
        readonly Permission[] _permission;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionFilter(Permission[] permission, IHttpContextAccessor httpContextAccessor)
        {
            _permission = permission;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var permissionIds = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissionIds").Value;
            var permisions = permissionIds.Split(",").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToList();
            foreach (int e in _permission)
            {
                if (!permisions.Any(x => x == e))
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
