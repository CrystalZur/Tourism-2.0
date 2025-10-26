using Microsoft.AspNetCore.Mvc;
using Tourism_2._0.Domain.Entities;

namespace Tourism_2._0.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            var entity = id == default ? new Service() : await dataManager.Services.GetServiceByIdAsync(id);
            ViewBag.ServiceCategories = await dataManager.ServiceCategories.GetServiceCategoriesAsync();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ServiceCategories = await dataManager.ServiceCategories.GetServiceCategoriesAsync();
                return View(entity);
            }

            if (titleImageFile != null)
            {
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await dataManager.Services.SaveServiceAsync(entity);

            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id)
        {
            await dataManager.Services.DeleteServiceAsync(id);

            return RedirectToAction("Index");
        }
    }
}
