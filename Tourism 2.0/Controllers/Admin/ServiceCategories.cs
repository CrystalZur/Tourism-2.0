using Microsoft.AspNetCore.Mvc;
using Tourism_2._0.Domain.Entities;

namespace Tourism_2._0.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id)
        {
            ServiceCategory? entity = id == default ? new ServiceCategory() : await dataManager.ServiceCategories.GetServiceCategoryByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
        {
            if (!ModelState.IsValid)
                return View(entity);

            await dataManager.ServiceCategories.SaveServiceCategoryAsync(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id)
        {
            await dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);

            return RedirectToAction("Index");
        }
    }
}
