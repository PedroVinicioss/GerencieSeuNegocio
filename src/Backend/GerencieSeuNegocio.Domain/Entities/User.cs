using GerencieSeuNegocio.Domain.Enums;

namespace GerencieSeuNegocio.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleType Role { get; set; } = RoleType.Customer;
        public List<Business> Businesses { get; set; } = [];

        protected User() { }
        public static User Create(string name, string email, string password)
        {
            return new User
            {
                Name = name,
                Email = email,
                Password = password
            };
        }
    }
}
