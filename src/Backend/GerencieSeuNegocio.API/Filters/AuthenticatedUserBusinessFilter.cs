using GerencieSeuNegocio.Communication.Responses;
using GerencieSeuNegocio.Domain.Extensions;
using GerencieSeuNegocio.Domain.Repositories.Business;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Domain.Security.Tokens;
using GerencieSeuNegocio.Exceptions;
using GerencieSeuNegocio.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace GerencieSeuNegocio.API.Filters
{
    public class AuthenticatedUserBusinessFilter : IAsyncAuthorizationFilter
    {
        private readonly IAccessTokenValidator _accessTokenValidator;
        private readonly IBusinessReadOnlyRepository _businessReadOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        public AuthenticatedUserBusinessFilter(
            IAccessTokenValidator accessTokenValidator,
            IBusinessReadOnlyRepository businessReadOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository)
        {
            _accessTokenValidator = accessTokenValidator;
            _businessReadOnlyRepository = businessReadOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context);

                var userUuid = _accessTokenValidator.ValidateAndGetUserUuid(token);

                var userExist = await _userReadOnlyRepository.ExistActiveUserWithUuid(userUuid);

                if (userExist.IsFalse())
                    throw new GerencieSeuNegocioException(ResourceMessagesException.USER_WITHOUT_PERMISSION_ACCESS_RESOURCE);

                var businessUuid = _accessTokenValidator.ValidateAndGetBusinessUuid(token);

                if (businessUuid.Equals(Guid.Empty))
                    throw new GerencieSeuNegocioException(ResourceMessagesException.BUSINESS_NOT_FOUND);

                var businessExist = await _businessReadOnlyRepository.ExistActiveBusinessUuid(businessUuid);

                if (businessExist.IsFalse())
                    throw new GerencieSeuNegocioException(ResourceMessagesException.BUSINESS_NOT_FOUND);

                var businessWithoutPermission = await _userReadOnlyRepository.ExistActiveBusinessOfUser(userUuid, businessUuid);

                if (businessWithoutPermission.IsFalse())
                    throw new GerencieSeuNegocioException(ResourceMessagesException.USER_WITHOUT_PERMISSION_ACCESS_BUSINESS);
            }
            catch (SecurityTokenExpiredException)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("TokenIsExpired")
                {
                    TokenIsExpired = true
                });
            }
            catch (GerencieSeuNegocioException ex)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ex.Message));
            }
            catch
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ResourceMessagesException.USER_WITHOUT_PERMISSION_ACCESS_RESOURCE));
            }
        }

        private static string TokenOnRequest(AuthorizationFilterContext context)
        {
            var authentication = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(authentication))
            {
                throw new GerencieSeuNegocioException(ResourceMessagesException.NO_TOKEN);
            }

            return authentication["Bearer ".Length..].Trim();
        }
    }
}
