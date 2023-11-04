using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Artimake_Web.Data; // Замените на ваше пространство имен, если оно отличается

var builder = WebApplication.CreateBuilder(args);

// Добавляем контекст базы данных в контейнер сервисов
builder.Services.AddDbContext<ArtimakeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ArtimakeConnection")));

// Добавляем сервисы для контроллеров
builder.Services.AddControllersWithViews(); // Используйте AddControllersWithViews для MVC контроллеров с представлениями

// Добавляем Swagger для документирования API, если вам это нужно
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настраиваем Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Принудительное перенаправление на HTTPS
app.UseHttpsRedirection();

// Используем статические файлы (например, CSS, JavaScript и т.д.)
app.UseStaticFiles();

// Используем промежуточное ПО для маршрутизации
app.UseRouting();

// Используем промежуточное ПО для аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

// Настраиваем маршруты для контроллеров
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Запускаем приложение
app.Run();
