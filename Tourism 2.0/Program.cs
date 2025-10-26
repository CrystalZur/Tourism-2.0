using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Tourism_2._0.Domain;
using Tourism_2._0.Domain.Repositories.Abstract;
using Tourism_2._0.Domain.Repositories.EntityFramework;
using Tourism_2._0.Infractructure;

namespace Tourism_2._0;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        //���������� appsettings.json
        var configBuild = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        //����������� ������ Project � ��������� ����� ��� ��������
        var configuration = configBuild.Build();
        var config = configuration.GetSection("Project").Get<AppConfig>()!;

        //����������� ��������� ��
        builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.Database.ConnectionString)
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

        builder.Services.AddTransient<IServiceCategoriesRepository, EFServiceCategoriesRepository>();
        builder.Services.AddTransient<IServicesRepository, EFServicesRepository>();
        builder.Services.AddTransient<DataManager>();

        //��c������ Identity �������
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        //Auth cookie
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "myTourAuth";
            options.Cookie.HttpOnly = true;
            options.LoginPath = "/account/login";
            options.AccessDeniedPath = "/admin/accessdenied";
            options.SlidingExpiration = true;
        });

        //����������� ����������� ������������
        builder.Services.AddControllersWithViews();

        //�������� ������������
        var app = builder.Build();

        //���������� ������������� ��������� ������
        app.UseStaticFiles();

        //����������� �������������
        app.UseRouting();

        //����������� �������������� � �����������
        app.UseCookiePolicy().UseAuthentication().UseAuthorization();

        //������������ ������ ��������
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
