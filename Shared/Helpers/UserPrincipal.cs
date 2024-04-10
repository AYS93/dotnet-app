using Microsoft.AspNetCore.Http;

namespace Shared.Helpers
{
    public class UserPrincipal
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserPrincipal(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetUserId()
        {
            var current = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            return !string.IsNullOrEmpty(current) ? int.Parse(current) : null;

        }
    }
}
