using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebApp.Pages;

[Authorize]
public class ContactModel : PageModel
{
    [BindProperty]
    public string Name { get; set; } = string.Empty;

    [BindProperty]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    public string Phone { get; set; } = string.Empty;

    [BindProperty]
    public string Subject { get; set; } = string.Empty;

    [BindProperty]
    public string Message { get; set; } = string.Empty;

    [BindProperty]
    public bool Subscribe { get; set; }

    public bool IsSubmitted { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        IsSubmitted = true;
        return Page();
    }
}
