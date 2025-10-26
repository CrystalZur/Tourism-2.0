using Tourism_2._0.Domain.Entities;
using Tourism_2._0.Models;

namespace Tourism_2._0.Infractructure;

public static class HelperDTO
{
    public static ServiceDTO TransformService(Service entity)
    {
        ServiceDTO entityDTO = new ServiceDTO(entity.Id, entity.ServiceCategory?.Title, entity.Title, entity.ShortDesc, entity.Desc, entity.Photo, entity.Type.ToString());

        return entityDTO;
    }

    public static IEnumerable<ServiceDTO> TransformServices(IEnumerable<Service> services)
    {
        List<ServiceDTO> entitiesDTO = [];

        foreach (Service entity in services)
            entitiesDTO.Add(TransformService(entity));
        return entitiesDTO;
    }
}
