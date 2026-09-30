# ASP.NET Core Razor Pages

Навчальний проєкт для знайомства з **ASP.NET Core Razor Pages** та базовими механізмами серверної веброзробки на .NET.

Проєкт демонструє, як Razor Page поєднує HTML-розмітку (`.cshtml`) з серверною логікою (`.cshtml.cs`), як обробляються HTTP-запити, параметри форм і GET-запити, а також як застосовується Entity Framework Core для роботи з даними.

## 🛠 Technology Stack

* **.NET 10**
* **ASP.NET Core Razor Pages**
* **C#**
* **Entity Framework Core 10**
* **SQL Server**
* **Bootstrap**
* **JavaScript / CSS**

## 📚 Що продемонстровано

### Razor Pages

Кожна сторінка складається з двох основних частин:

```text
Page.cshtml
Page.cshtml.cs
```

`.cshtml` відповідає за представлення, а `PageModel` у `.cshtml.cs` містить серверну логіку сторінки.

Наприклад:

```text
Pages/
├── Index.cshtml
├── Index.cshtml.cs
├── Square.cshtml
├── Square.cshtml.cs
├── UploadFile.cshtml
├── UploadFile.cshtml.cs
├── DownloadFile.cshtml
└── DownloadFile.cshtml.cs
```

Це добре видно на прикладі `Index`: сторінка отримує дані з `IndexModel`, а метод `OnGet()` виконується під час GET-запиту.

## 🔹 Основні приклади

### `Index`

Базова Razor Page, яка демонструє:

* `PageModel`
* `OnGet()`
* передачу даних через властивості моделі
* `ViewData`
* виклик C#-методу безпосередньо з Razor-розмітки

### `Square`

Невеликий приклад роботи з параметрами GET-запиту.

Параметри:

```text
/Square?a=10&h=5
```

За допомогою `[BindProperty(SupportsGet = true)]` значення параметрів прив'язуються до властивостей `PageModel`.

Після цього сервер обчислює площу трикутника:

```text
S = (a × h) / 2
```

Це простий, але дуже наочний приклад **model binding** у Razor Pages.

### `UploadFile`

Більш практичний приклад, який демонструє повний цикл роботи з файлами:

```text
Browser
   ↓
multipart/form-data
   ↓
IFormFile
   ↓
wwwroot/Files
   ↓
SQL Server
```

Сторінка підтримує:

* вибір файлу;
* drag & drop;
* попередній перегляд вибраного файлу;
* завантаження на сервер;
* збереження інформації про файл у БД;
* відображення списку завантажених файлів.

Клієнтська частина також містить JavaScript для drag & drop та попереднього перегляду.

### `DownloadFile`

Демонструє повернення файлу з серверної сторони через `IActionResult` та `File(...)`.

Це простий приклад того, що Razor Page може повертати не тільки HTML, а й інший HTTP response.

## 🗄 Entity Framework Core

Для роботи з файлами використовується Entity Framework Core.

Основна модель:

```csharp
public class FileModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Path { get; set; }
}
```

Контекст бази даних:

```text
ApplicationContext
        │
        └── DbSet<FileModel>
                    │
                    ↓
                SQL Server
```

Підключення до БД налаштоване через `appsettings.json`.

## 📁 Структура проєкта

```text
RazorPagesApp/
│
├── Models/
│   ├── ApplicationContext.cs
│   └── FileModel.cs
│
├── Pages/
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── Square.cshtml
│   ├── Square.cshtml.cs
│   ├── UploadFile.cshtml
│   ├── UploadFile.cshtml.cs
│   ├── DownloadFile.cshtml
│   ├── DownloadFile.cshtml.cs
│   └── Shared/
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── Images/
│   ├── Files/
│   └── lib/
│
├── Program.cs
├── appsettings.json
└── RazorPagesApp.csproj
```

## 🚀 Як запустити проєкт

Потрібні:

* .NET 10 SDK
* SQL Server
* Visual Studio 2026 або інше середовище з підтримкою .NET

Клонування:

```bash
git clone https://github.com/sunmeat/aspnetcore_razor1.git
cd aspnetcore_razor1
```

Запуск:

```bash
dotnet run --project RazorPagesApp
```

Перед запуском перевірте connection string у:

```text
RazorPagesApp/appsettings.json
```

## 🎯 Для чого цей проєкт

Проєкт призначений для практичного знайомства з:

* Razor Pages;
* `PageModel`;
* Razor syntax;
* `OnGet` та `OnPost`;
* model binding;
* GET-параметрами;
* `IFormFile`;
* завантаженням і поверненням файлів;
* `IWebHostEnvironment`;
* Entity Framework Core;
* `DbContext` та `DbSet`;
* SQL Server;
* static files;
* JavaScript у Razor Pages.

---

### 💡 Головна ідея

Цей проєкт варто розглядати як невеликий **навчальний полігон ASP.NET Core**.

Тут немає складної архітектури заради самої архітектури. Навпаки, кожна сторінка показує окремий механізм фреймворку, щоб можна було відкрити `.cshtml`, перейти до відповідного `.cshtml.cs` і буквально простежити шлях:

**HTTP request → PageModel → C# logic → Razor markup → HTTP response**

Саме тому проєкт зручно використовувати як перший крок для знайомства з моделлю розробки Razor Pages.
