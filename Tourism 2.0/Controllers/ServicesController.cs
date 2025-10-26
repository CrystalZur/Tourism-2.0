using Microsoft.AspNetCore.Mvc;
using Tourism_2._0.Domain;
using Tourism_2._0.Domain.Entities;
using Tourism_2._0.Infractructure;
using Tourism_2._0.Models;

namespace Tourism_2._0.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;

        public ServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _dataManager.Services.GetServicesAsync();

            var listDTO = HelperDTO.TransformServices(list);

            return View(listDTO);
        }

        public async Task<IActionResult> Show(int id)
        {
            var entity = await _dataManager.Services.GetServiceByIdAsync(id);

            if (entity == null) 
                return NotFound();

            var entityDTO = HelperDTO.TransformService(entity);

            return View(entityDTO);
        }
    }
}
