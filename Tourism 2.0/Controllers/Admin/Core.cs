using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tourism_2._0.Domain;

namespace Tourism_2._0.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public partial class AdminController(DataManager dataManager, IWebHostEnvironment hostEnvironment) : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.ServiceCategories = await dataManager.ServiceCategories.GetServiceCategoriesAsync();
            ViewBag.Services = await dataManager.Services.GetServicesAsync();
            return View();
        }

        public async Task<string> SaveImg(IFormFile img)
        {
            var path = Path.Combine(hostEnvironment.WebRootPath, "img/", img.FileName);
            await using FileStream stream = new(path, FileMode.Create);
            await img.CopyToAsync(stream);

            return path;
        }

        public async Task<string> SaveEditorImg()
        {
            var img = Request.Form.Files[0];
            await SaveImg(img);

            return JsonSerializer.Serialize(new { location = Path.Combine("/img/", img.FileName) });
        }
    }
}
