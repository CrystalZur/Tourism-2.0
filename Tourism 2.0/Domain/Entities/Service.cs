using System.ComponentModel.DataAnnotations;
using Tourism_2._0.Domain.Enums;

namespace Tourism_2._0.Domain.Entities
{
    public class Service : EntityBase
    {
        [Display(Name = "Выберите категорию услуги")]
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }

        [Display(Name = "Краткое описание")]
        [MaxLength(1000)]
        public string? ShortDesc { get; set; }

        [Display(Name = "Описание")]
        [MaxLength(100000)]
        public string? Desc { get; set; }

        [Display(Name = "Картинка")]
        [MaxLength(300)]
        public string? Photo { get; set; }

        [Display(Name = "Тип услуги")]
        public ServiceTypeEnum Type { get; set; }
    }
}
