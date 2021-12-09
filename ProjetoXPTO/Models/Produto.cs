using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoXPTO.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        public int Preco { get; set; }
        public string CodigoBarras { get; set; }
        public string Imagem { get; set; }
        [Required]
        public string Categoria { get; set; }
    }
}
