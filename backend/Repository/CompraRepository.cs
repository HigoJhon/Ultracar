using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CompraRepository : ICompraRepository
    {
        private readonly AppDbContext _context;

        public CompraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Compras>> GetAll()
        {
            return await _context.Compras.Include(c => c.Peca).ToListAsync();
        }

        public async Task<Compras> GetById(int id)
        {
            return await _context.Compras.Include(c => c.Peca).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Compras> Add(Compras compra)
        {
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task<Compras> Update(Compras compra)
        {
            _context.Compras.Update(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task<Compras> Delete(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
                await _context.SaveChangesAsync();
            }
            return compra;
        }
    }
}
