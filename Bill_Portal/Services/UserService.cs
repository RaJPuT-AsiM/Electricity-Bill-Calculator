using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Bill_Portal.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
