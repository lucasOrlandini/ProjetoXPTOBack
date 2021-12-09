using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoXPTO.Models;
using ProjetoXPTO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace ProjetoXPTO.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                var produtos = await _produtoService.GetProdutos();
                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Request Invalid");
            }
        }
        [HttpGet("ProdutosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProdutoByNome([FromQuery] string nome)
        {
            try
            {
                var produtos = await _produtoService.GetProdutoByNome(nome);
                if (produtos.Count() == 0)
                    return NotFound("Não existem produtos com o critério {nome}");

                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Request Invalid");
            }
        }
        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProduto(int id)
        {
            try
            {
                var produto = await _produtoService.GetProduto(id);
                if (produto == null)
                    return NotFound($"não existe produto com  id={id}");
                return Ok(produto);
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Produto produto)
        {
            try
            {
                await _produtoService.CreateProduto(produto);
                return CreatedAtRoute(nameof(GetProduto), new { id = produto.Id }, produto);
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Produto produto)
        {
            try
            {
                if (produto.Id == id)
                {
                    await _produtoService.UpdateProduto(produto);
                    return Ok($"Produto com id={id}foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados Inconsistentes ");
                }
            }
            catch
            {

                return BadRequest("Request Invalid");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var produto = await _produtoService.GetProduto(id);
                if (produto != null)
                {
                    await _produtoService.DeleteProduto(produto);
                    return Ok($"Produto de id={id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Aluno com id= {id} não encontrado ");
                }
            }
            catch
            {

                return BadRequest("Request Invalid");
            }
        }




    }
}
