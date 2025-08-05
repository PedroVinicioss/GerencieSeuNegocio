using GerencieSeuNegocio.Communication.Responses.Token;

namespace GerencieSeuNegocio.Communication.Responses.User.Create
{
    public class ResponseCreateUserJson
    {
        public string Name { get; set; } = string.Empty;
        public ResponseTokensJson Tokens { get; set; } = default!;
    }
}
