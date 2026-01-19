using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; }
        public IndexModel()
        {
            Message = "Ласкаво просимо у світ ASP.NET Core Razor Pages";           
        }

        public void OnGet()
        {
            ViewData["Message"] = "відпрацював метод OnGet в Index.cshtml.cs";
        }

        public string PrintTime() => DateTime.Now.ToShortTimeString();
    }
}