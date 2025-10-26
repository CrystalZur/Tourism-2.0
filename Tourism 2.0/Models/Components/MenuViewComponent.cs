using Microsoft.AspNetCore.Mvc;
using Tourism_2._0.Domain;
using Tourism_2._0.Infractructure;

namespace Tourism_2._0.Models.Components;

public class MenuViewComponent : ViewComponent
{
    private readonly DataManager _dataManager;

    public MenuViewComponent(DataManager dataManager) => _dataManager = dataManager;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var list = await _dataManager.Services.GetServicesAsync();

        var listDTO = HelperDTO.TransformServices(list);

        return await Task.FromResult((IViewComponentResult)View("Default", listDTO));
    }
}
