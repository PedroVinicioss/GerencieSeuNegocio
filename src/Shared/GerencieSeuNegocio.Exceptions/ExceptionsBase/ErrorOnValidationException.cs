namespace GerencieSeuNegocio.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : GerencieSeuNegocioException
    {
        public IList<string> ErrorMessages { get; set; }
        public ErrorOnValidationException(IList<string> errorMessages) : base(string.Empty)
        {
            ErrorMessages = errorMessages;
        }
    }
}
