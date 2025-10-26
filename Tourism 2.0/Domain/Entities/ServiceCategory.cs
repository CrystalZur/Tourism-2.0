namespace Tourism_2._0.Domain.Entities
{
    public class ServiceCategory : EntityBase
    {
        public ICollection<Service>? Services { get; set; }
    }
}
