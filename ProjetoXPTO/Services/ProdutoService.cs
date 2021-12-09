using Microsoft.EntityFrameworkCore;
using ProjetoXPTO.Context;
using ProjetoXPTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoXPTO.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            try
            {
                return await _context.Produtos.ToListAsync();

            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Produto>> GetProdutoByNome(string nome)
        {
            IEnumerable<Produto> produtos;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                produtos =  await _context.Produtos.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                produtos = await GetProdutos();
            }
            return produtos;
        }
        public async Task<Produto> GetProduto(int id)
        {
            var produto =  await _context.Produtos.FindAsync(id);
            return produto;
        }
        public async Task CreateProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
       
    }
}
