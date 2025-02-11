using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IAppDbContext _context;

        public ClientesRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Clientes> Add(Clientes cliente)
        {
            var existingCliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Nome == cliente.Nome);
            if (existingCliente != null)
            {
                throw new ArgumentException("Cliente já cadastrado!");
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public async Task<Clientes> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                throw new ArgumentException("Cliente não encontrado!");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public async Task<List<Clientes>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetCliente(int id)
        {
            var existCliente = await _context.Clientes.FindAsync(id);

            if (existCliente == null)
            {
                throw new ArgumentException("Cliente não encontrado!");
            }

            return existCliente;
        }

        public async Task<Clientes> Update(Clientes cliente)
        {
            var existCliente = await _context.Clientes.FindAsync(cliente.Id);

            if (existCliente == null)
            {
                throw new ArgumentException("Cliente não encontrado!");
            }

            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            return cliente;
        }
    }
}