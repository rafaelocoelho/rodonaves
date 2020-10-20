using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RodonavesAPI.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public int EstadoId { get; set; }

        [
            DisplayName("Cidade"),
            Required(ErrorMessage = "O campo Cidade é obrigatório.")
        ]
        public string Descricao { get; set; }
    }
}
