using System;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repositorio
{
    public interface ITreinamentoRepository : IRepository<Treinamento>
    {
        List<Treinamento> BuscarTreinamentos(string termo);
    }
}
