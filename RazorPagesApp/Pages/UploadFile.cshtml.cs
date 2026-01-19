using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class UploadFileModel : PageModel
    {
        // список файлів для відображення на сторінці
        public IEnumerable<FileModel> Files { get; set; } = default!;

        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _appEnvironment; // сервіс для роботи з файлами

        public UploadFileModel(
            ApplicationContext context,
            IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        /// <summary>
        /// завантажуємо список усіх збережених файлів при GET-запиті
        /// </summary>
        public async Task OnGetAsync()
        {
            if (_context.Files != null)
            {
                Files = await _context.Files
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        // файл, який прийшов від користувача через форму
        [BindProperty] // прив'язка властивості до форми, щоб отримати файл із запиту
        public IFormFile? UploadedFile { get; set; }

        /// <summary>
        /// обробка завантаження файлу (POST-запит)
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            if (UploadedFile is null || UploadedFile.Length == 0)
            {
                return RedirectToPage();
            }

            try
            {
                // відносний шлях у папці wwwroot/Files
                string fileName = UploadedFile.FileName;
                string relativePath = $"/Files/{fileName}";
                string physicalPath = Path.Combine(_appEnvironment.WebRootPath, "Files", fileName);

                // створюємо папку Files, якщо її ще немає
                Directory.CreateDirectory(Path.GetDirectoryName(physicalPath)!);

                // зберігаємо файл на диск
                using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await UploadedFile.CopyToAsync(fileStream);
                }

                // зберігаємо інформацію про файл у базу даних
                var fileRecord = new FileModel
                {
                    Name = fileName,
                    Path = relativePath
                };

                _context.Files.Add(fileRecord);
                await _context.SaveChangesAsync();

                return RedirectToPage("./UploadFile");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Помилка при завантаженні файлу: {ex.Message}");
                await OnGetAsync(); // зберегти список файлів
                return Page();
            }
        }
    }
}