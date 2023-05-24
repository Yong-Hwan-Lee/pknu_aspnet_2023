using aspnet01_webapp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Data���� ���� ApplicationDbContext�� ����ϰڴٴ� ���� �߰�
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
    // appsettings.json ConnectionStrings���� ���� ���ڿ� �Ҵ�
    builder.Configuration.GetConnectionString("DefaultConnection"),
    // ���Ṯ�ڿ��� DB�� ���������� �ڵ����� ����ð�
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));
//2. ASP.NET Identity - ASP.NET������ ���� ���� ����
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// ��й�ȣ ��å ���� ����
builder.Services.Configure<IdentityOptions>(options =>
{
    // Custom Password policy   // �ǹ������� �Ʒ��Ͱ��� �����ϸ� �ȵ�
    options.Password.RequireDigit = false;  // ������ �ʿ俩��
    options.Password.RequireLowercase = false;  // �ҹ��� �ʿ俩��
    options.Password.RequireUppercase = false;  // �빮�� �ʿ俩��
    options.Password.RequireNonAlphanumeric = false; // Ư������ �ʿ俩��
    options.Password.RequiredLength = 4; // �ּ� �н����� ���� ��
    options.Password.RequiredUniqueChars = 0; // ��ȣ �������� ����
});

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
app.UseAuthentication(); //3. ASP.NET Identity - �����߰�

app.UseAuthorization(); //����

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();