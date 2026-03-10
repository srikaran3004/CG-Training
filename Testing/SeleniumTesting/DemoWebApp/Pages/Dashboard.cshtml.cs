using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebApp.Pages;

[Authorize]
public class DashboardModel : PageModel
{
    public string WelcomeMessage => $"Welcome back, {User.Identity?.Name}!";

    public string UserRole => User.IsInRole("Admin") ? "Administrator" : "Standard User";

    public int TotalProducts => 10;
    public int TotalUsers => 2;
    public int PendingOrders => 5;

    public void OnGet() { }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Index");
    }
}
