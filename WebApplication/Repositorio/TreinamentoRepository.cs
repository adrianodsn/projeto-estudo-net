using System.Collections.Generic;
using System.Linq;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class TreinamentoRepository : Repository<Treinamento>, ITreinamentoRepository
    {
        readonly ApplicationContext Context;

        public TreinamentoRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public List<Treinamento> BuscarTreinamentos(string termo)
        {
            IQueryable<Treinamento> treinamentos = Context.Treinamentos
                .AsNoTracking()
                .OrderBy(x => x.Nome);

            if (!string.IsNullOrEmpty(termo))
            {
                treinamentos = treinamentos.Where(x => x.Nome.Contains(termo));
            }

            return treinamentos.ToList();
        }
    }

}