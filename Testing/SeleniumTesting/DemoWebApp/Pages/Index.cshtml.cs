using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DemoWebApp.Pages;

public class IndexModel : PageModel
{
    private static readonly Dictionary<string, string> ValidUsers = new()
    {
        { "admin", "Admin@123" },
        { "user", "User@123" }
    };

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public string? ErrorMessage { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToPage("/Dashboard");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Please enter both username and password.";
            return Page();
        }

        if (ValidUsers.TryGetValue(Username, out var validPassword) && validPassword == Password)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, Username),
                new(ClaimTypes.Role, Username == "admin" ? "Admin" : "User")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToPage("/Dashboard");
        }

        ErrorMessage = "Invalid username or password. Please try again.";
        return Page();
    }
}
