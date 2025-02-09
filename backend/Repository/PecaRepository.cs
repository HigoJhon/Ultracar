using backend.Context;
using backend.Models;

namespace backend.Repository
{
    public class PecaRepository : IPecaRepository
    {
        private readonly IAppContext _context;
        public PecaRepository(IAppContext context)
        {
            _context = context;
        }

        public List<Peca> GetAll()
        {
            return _context.Pecas.ToList();
        }

        public Peca GetPeca(int id)
        {
            var existPeca = _context.Pecas.Find(id);
            if (existPeca == null)
            {
                throw new ArgumentException("Peça não encontrada!");
            }

            return existPeca;
        }
    }
}
