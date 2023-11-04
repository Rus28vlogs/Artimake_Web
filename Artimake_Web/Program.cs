using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Artimake_Web.Data; // �������� �� ���� ������������ ����, ���� ��� ����������

var builder = WebApplication.CreateBuilder(args);

// ��������� �������� ���� ������ � ��������� ��������
builder.Services.AddDbContext<ArtimakeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ArtimakeConnection")));

// ��������� ������� ��� ������������
builder.Services.AddControllersWithViews(); // ����������� AddControllersWithViews ��� MVC ������������ � ���������������

// ��������� Swagger ��� ���������������� API, ���� ��� ��� �����
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ����������� Swagger ������ � ������ ����������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// �������������� ��������������� �� HTTPS
app.UseHttpsRedirection();

// ���������� ����������� ����� (��������, CSS, JavaScript � �.�.)
app.UseStaticFiles();

// ���������� ������������� �� ��� �������������
app.UseRouting();

// ���������� ������������� �� ��� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// ����������� �������� ��� ������������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ��������� ����������
app.Run();
