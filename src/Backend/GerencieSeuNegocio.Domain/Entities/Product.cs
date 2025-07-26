using GerencieSeuNegocio.Domain.Enums;

namespace GerencieSeuNegocio.Domain.Entities
{
    public class Product : EntityBase
    {
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ProductType Category { get; set; } = ProductType.Undefined;
    }
}
