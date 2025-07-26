using GerencieSeuNegocio.Domain.Enums;

namespace GerencieSeuNegocio.Domain.Entities
{
    public class Business : EntityBase
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public BusinessType Type { get; set; } = BusinessType.Undefined;
    }
}
