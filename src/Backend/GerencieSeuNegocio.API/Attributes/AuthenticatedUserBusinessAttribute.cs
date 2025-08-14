using GerencieSeuNegocio.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Attributes
{
    public class AuthenticatedUserBusinessAttribute : TypeFilterAttribute
    {
        public AuthenticatedUserBusinessAttribute() : base(typeof(AuthenticatedUserBusinessFilter))
        {
        }
    }
}
