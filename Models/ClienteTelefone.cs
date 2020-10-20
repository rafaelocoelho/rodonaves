using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RodonavesAPI.Models
{
    public class ClienteTelefone
    {
        [
            Key, 
            ForeignKey("ClienteId")
        ]
        public int Id { get; set; }

        [
            DisplayName("Telefone"),
            Required(ErrorMessage = "O campo Telefone é obrigatório"),
            StringLength(11, ErrorMessage = "O campo Telefone precisar ter entre 10 e 11 digitos.", MinimumLength = 10)
        ]
        public string Numero { get; set; }

        public Cliente Cliente { get; set; }
    }
}
