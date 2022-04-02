
namespace WebApplication.Repositorio
{
    public interface IUnitOfWork
    {
        IEstadoRepository EstadoRepository { get; }
        ICidadeRepository CidadeRepository { get; }
        IPessoaRepository PessoaRepository { get; }
        void Commit();
    }
}