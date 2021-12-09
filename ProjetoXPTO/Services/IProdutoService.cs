using ProjetoXPTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoXPTO.Services
{
   public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProduto(int id);
        Task<IEnumerable<Produto>> GetProdutoByNome(string nome);
        Task CreateProduto(Produto produto);
        Task UpdateProduto(Produto produto);
        Task DeleteProduto(Produto produto);
    }
}
