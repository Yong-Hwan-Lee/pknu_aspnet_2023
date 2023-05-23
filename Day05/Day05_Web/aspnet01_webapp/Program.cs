using aspnet01_webapp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Data���� ���� ApplicationDbContext�� ����ϰڴٴ� ���� �߰�
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
    // appsettings.json ConnectionStrings���� ���� ���ڿ� �Ҵ�
    builder.Configuration.GetConnectionString("DefaultConnection"),
    // ���Ṯ�ڿ��� DB�� ���������� �ڵ����� ���ð�
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
