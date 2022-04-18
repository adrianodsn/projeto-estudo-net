using System;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext Context = null;

        private EstadoRepository _EstadoRepository = null;
        private CidadeRepository _CidadeRepository = null;
        private PessoaRepository _PessoaRepository = null;
        private TreinamentoRepository _TreinamentoRepository = null;

        public UnitOfWork()
        {
            Context = new ApplicationContext();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public IEstadoRepository EstadoRepository
        {
            get
            {
                if (_EstadoRepository == null)
                {
                    _EstadoRepository = new EstadoRepository(Context);
                }

                return _EstadoRepository;
            }
        }

        public ICidadeRepository CidadeRepository
        {
            get
            {
                if (_CidadeRepository == null)
                {
                    _CidadeRepository = new CidadeRepository(Context);
                }

                return _CidadeRepository;
            }
        }

        public IPessoaRepository PessoaRepository
        {
            get
            {
                if (_PessoaRepository == null)
                {
                    _PessoaRepository = new PessoaRepository(Context);
                }

                return _PessoaRepository;
            }
        }

        public ITreinamentoRepository TreinamentoRepository
        {
            get
            {
                if (_TreinamentoRepository == null)
                {
                    _TreinamentoRepository = new TreinamentoRepository(Context);
                }

                return _TreinamentoRepository;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}