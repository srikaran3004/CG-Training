namespace CustomFiltersCustomMiddleware_Authorization.Services
{
    public class FakeUserService
    {
        public string GetUserRole(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            if (username.ToLower() == "admin")
            {
                return "Admin";
            }
            if (username.ToLower() == "user")
            {
                return "User";
            }
            return null;
        }
    }
}
