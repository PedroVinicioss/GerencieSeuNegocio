namespace GerencieSeuNegocio.Exceptions.ExceptionsBase
{
    public class InvalidLoginException : GerencieSeuNegocioException
    {
        public InvalidLoginException() : base(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID) { }
    }
}
