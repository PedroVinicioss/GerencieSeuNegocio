namespace GerencieSeuNegocio.Domain.Extensions
{
    public static class BooleanHelper
    {
        public static bool IsFalse(this bool value)
        {
            return !value;
        }
    }
}
