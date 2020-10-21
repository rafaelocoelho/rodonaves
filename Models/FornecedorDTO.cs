using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RodonavesAPI.Models
{
    public class FornecedorDTO
    {
        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public int CidadeId { get; set; }

        public int EstadoId { get; set; }

        public string CEP { get; set; }

        public bool Inativo { get; set; }

        public ICollection<FornecedorTelefone> FornecedorTelefones { get; set; }
    }
}
