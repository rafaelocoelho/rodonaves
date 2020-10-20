using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RodonavesAPI.Models
{
    public class Cliente
    {

        [
            Key,
            DisplayName("Código")
        ]
        public int Id { get; set; }

        [
            DisplayName("Nome Completo"),
            Required(ErrorMessage = "O campo Nome Completo é obrigatório."),
            MinLength(5, ErrorMessage = "O campo Nome Completo precisa ter pelo menos 5 caracteres."),
            MaxLength(150, ErrorMessage = "O campo Nome Completo pode ter no máximo 150 caracteres.")
        ]
        public string NomeCompleto { get; set; }

        [
            Required(ErrorMessage = "O campo CPF é obrigatório."),
            StringLength(11, ErrorMessage = "O campo CPF precisa ter 11 digitos.", MinimumLength = 11)
        ]
        public string CPF { get; set; }

        [
            Required(ErrorMessage = "O campo Endereço é obrigatório."),
            DisplayName("Nome Completo"),
            MinLength(5, ErrorMessage = "O campo Endereço precisar ter pelo menos 5 caracteres."),
            MaxLength(150, ErrorMessage = "O campo Endereço pode ter no máximo 150 caracteres.")
        ]
        public string Endereco { get; set; }

        [
            Required(ErrorMessage = "O campo Bairro é obrigatório."),
            MinLength(5, ErrorMessage = "O campo Bairro precisar ter pelo menos 5 caracteres."),
            MaxLength(150, ErrorMessage = "O campo Bairro pode ter no máximo 150 caracteres.")
        ]
        public string Bairro { get; set; }

        [
            Required(ErrorMessage = "O campo Cidade é obrigatório.")
        ]
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public int EstadoId { get; set; }

        [
            Required(ErrorMessage = "O campo CEP é obrigatório."),
            StringLength(8, ErrorMessage = "O campo CEP precisar ter pelo 8 digitos.", MinimumLength = 8)
        ]
        public string CEP { get; set; }

        [
            DisplayName("Criado em"),
            DatabaseGenerated(DatabaseGeneratedOption.Identity)
        ]
        public DateTime DataDeCriacao { get; set; }

        [DisplayName("Atualizado em")]
        public DateTime DataDeAtualizacao { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigário.")]

        public ICollection<ClienteTelefone> ClienteTelefones { get; set; }
    }
}
