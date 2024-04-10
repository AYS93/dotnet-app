using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using WebApi.Attributes.Filters;

namespace WebApi.Attributes
{
    public class HasPermissionAttribute : TypeFilterAttribute
    {
        public HasPermissionAttribute(params Permission[] permission) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permission.ToArray() };
        }
    }
}
