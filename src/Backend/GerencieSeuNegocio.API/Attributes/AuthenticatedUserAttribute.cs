using GerencieSeuNegocio.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GerencieSeuNegocio.API.Attributes
{
    public class AuthenticatedUserAttribute : TypeFilterAttribute
    {
        public AuthenticatedUserAttribute() : base(typeof(AuthenticatedUserFilter))
        {
        }
    }
}
