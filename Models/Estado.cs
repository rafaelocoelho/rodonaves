using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RodonavesAPI.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [
            DisplayName("Estado"),
            Required(ErrorMessage = "O campo Estado é obrigatório.")
        ]
        public string Descricao { get; set; }

        [
            DisplayName("Sigla"),
            Required(ErrorMessage = "O campo UF é obrigatório."),
            MinLength(2, ErrorMessage = "O campo UF precisa ter no mínimo 2 caracteres."),
            MaxLength(2, ErrorMessage = "O campo UF pode ter apenas 2 caracteres.")
        ]
        public string Sigla { get; set; }
    }
}
