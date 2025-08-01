namespace GerencieSeuNegocio.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
