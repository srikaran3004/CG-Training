using CustomFiltersCustomMiddleware_Authorization.Services;
using System.Security.Claims;
namespace CustomFiltersCustomMiddleware_Authorization.Middleware
{
    public class RoleMiddleware
    {
        private readonly RequestDelegate _next;
        public RoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var fakeUserService = new FakeUserService();
            var username = context.Request.Headers["username"].FirstOrDefault();
            var role = fakeUserService.GetUserRole(username);

            if (!string.IsNullOrEmpty(role))
            {
                var claims = new List<Claim>
                {
                      new Claim(ClaimTypes.Name, username),
                      new Claim(ClaimTypes.Role, role)
                };

                var identity = new ClaimsIdentity(claims, "CustomHeaderAuth");
                context.User = new ClaimsPrincipal(identity);
            }

            await _next(context);
        }
    }
}
