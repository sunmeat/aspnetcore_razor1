using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class DownloadFileModel : PageModel
    {
        public string Message { get; private set; } = "";
        public IActionResult OnGet() // якщо метод має тип повернення void (або Task у асинхронному варіанті), то ASP.NET Core автоматично вважає, що треба відрендерити саму сторінку (тобто повертається PageResult і викликається .cshtml файл)
        {
            string path = "~/Images/олень.jpg";
            string type = "image/jpeg";
            string result = "olen.jpg";
            Message = "Файл " + result + " завантажено.";
            return File(path, type, result);
        }
    }
}