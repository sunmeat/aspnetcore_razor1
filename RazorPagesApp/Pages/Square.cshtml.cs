using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class SquareModel : PageModel
    {
        // повідомлення, яке виводитиметься на сторінці
        public string Message { get; private set; } = "";

        // властивості, прив'язані до GET-параметрів (?a=10&h=5)
        // SupportsGet = true дозволяє прив'язувати значення при GET-запиті
        [BindProperty(SupportsGet = true, Name = "a")]
        public int BaseTriangle { get; set; }

        [BindProperty(SupportsGet = true, Name = "h")]
        public int HeightTriangle { get; set; }

        public void OnGet() // різниця між OnGet і OnGetAsync лише в тому, що другий повертає Task
        {
            // обчислюємо площу трикутника: S = (основа × висота) / 2
            double square = BaseTriangle * HeightTriangle / 2.0;

            Message = $"Площа трикутника з основою {BaseTriangle} " +
                      $"та висотою {HeightTriangle} дорівнює {square}";

            // альтернативний запис через інтерполяцію (більш читабельний):
            // Message = $"Площа трикутника з основою {BaseTriangle} та висотою {HeightTriangle} дорівнює {square}";
        }
    }
}