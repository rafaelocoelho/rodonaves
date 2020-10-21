using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RodonavesAPI.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [
            DisplayName("Razão Social"),
            Required(ErrorMessage = "O campo Razão Social é obrigatório."),
            MinLength(15, ErrorMessage = "O campo Razão Social precisa ter pelo menos 15 caracteres."),
            MaxLength(150, ErrorMessage = "O campo Razão Social pode ter no máximo 150 caracteres.")
        ]
        public string RazaoSocial { get; set; }

        [
            DisplayName("Nome Fantasia"),
            Required(ErrorMessage = "O campo Nome Fantasia é obrigatório."),
            StringLength(150, ErrorMessage = "O campo Nome Fantasia pode ter no máximo 150 caracteres.")
        ]
        public string NomeFantasia { get; set; }

        [
            Required(ErrorMessage = "O campo CNPJ é obrigatório."),
            StringLength(14, ErrorMessage = "O campo CNPJ precisa ter 14 digitos.", MinimumLength = 14)
        ]
        public string CNPJ { get; set; }

        [
            Required(ErrorMessage = "O campo Endereço é obrigatório."),
            DisplayName("Nome Completo"),
            StringLength(150, ErrorMessage = "O campo Endereço pode ter entre 5 e 150 caracteres.", MinimumLength = 5)

        ]
        public string Endereco { get; set; }

        [
            Required(ErrorMessage = "O campo Bairro é obrigatório."),
            StringLength(150, ErrorMessage = "O campo Bairro pode ter entre 5 e 150 caracteres.", MinimumLength = 5)
        ]
        public string Bairro { get; set; }

        [
            ForeignKey("ClienteId"),
            Required(ErrorMessage = "O campo Cidade é obrigatório.")
        ]
        public int CidadeId { get; set; }

        [
            ForeignKey("EstadoId"),
            Required(ErrorMessage = "O campo Estado é obrigatório.")
        ]
        public int EstadoId { get; set; }

        [
            Required(ErrorMessage = "O campo CEP é obrigatório."),
            StringLength(8, ErrorMessage = "O campo CEP precisa 8 digitos.", MinimumLength = 8)
        ]
        public string CEP { get; set; }

        [
            DisplayName("Criado em"),
            DatabaseGenerated(DatabaseGeneratedOption.Identity)
        ]
        public DateTime DataDeCriacao { get; set; }

        [
            DisplayName("Atualizado em"),
            DatabaseGenerated(DatabaseGeneratedOption.Computed)
        ]
        public DateTime DataDeAtualizacao { get; set; }

        [DefaultValue(false)]
        public bool Inativo { get; set; }

        public virtual ICollection<FornecedorTelefone> FornecedorTelefones { get; set; }
    }
}
