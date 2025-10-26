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

        //Подключаем appsettings.json
        var configBuild = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        //Оборачиваем секцию Project в объектную форму для удобства
        var configuration = configBuild.Build();
        var config = configuration.GetSection("Project").Get<AppConfig>()!;

        //Подключение контекста БД
        builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.Database.ConnectionString)
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

        builder.Services.AddTransient<IServiceCategoriesRepository, EFServiceCategoriesRepository>();
        builder.Services.AddTransient<IServicesRepository, EFServicesRepository>();
        builder.Services.AddTransient<DataManager>();

        //Наcтройка Identity систему
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

        //Подключение функционала контроллеров
        builder.Services.AddControllersWithViews();

        //Собираем конфигурацию
        var app = builder.Build();

        //Подключаем использование статичных файлов
        app.UseStaticFiles();

        //Подключение маршрутизации
        app.UseRouting();

        //Подключение аутентификации и авторизации
        app.UseCookiePolicy().UseAuthentication().UseAuthorization();

        //Регистрируем нужные маршруты
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
