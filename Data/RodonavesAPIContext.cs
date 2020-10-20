using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RodonavesAPI.Models;

namespace RodonavesAPI.Data
{
    public class RodonavesAPIContext : DbContext
    {
        public RodonavesAPIContext (DbContextOptions<RodonavesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RodonavesAPI.Models.Estado> Estado { get; set; }

        public DbSet<RodonavesAPI.Models.Cidade> Cidade { get; set; }

        public DbSet<RodonavesAPI.Models.Cliente> Cliente { get; set; }

        public DbSet<RodonavesAPI.Models.ClienteTelefone> ClienteTelefones { get; set; }

        public DbSet<RodonavesAPI.Models.Fornecedor> Fornecedor { get; set; }

        public DbSet<RodonavesAPI.Models.FornecedorTelefone> FornecedorTelefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             Recupera os dados de estados e cidades presentes no arquivo JSON
             */
            string JsonEstados = File.ReadAllText(".\\Seeds\\Estados.json");
            string JsonCidades = File.ReadAllText(".\\Seeds\\Cidades.json");

            /*
             Deserializa os dados obtidos em JSON convertendo-os em uma lista 
             de objetos do tipo Estado e Cidade
             */
            List<Estado> estados = JsonConvert.DeserializeObject<List<Estado>>(JsonEstados);
            List<Cidade> cidades = JsonConvert.DeserializeObject<List<Cidade>>(JsonCidades);

            /*
             Gera script para popular as estidades estado e cidade
            */
            foreach (Estado estado in estados)
            {
                modelBuilder.Entity<Estado>().HasData(estado);
            }

            foreach (Cidade cidade in cidades)
            {
                modelBuilder.Entity<Cidade>().HasData(cidade);
            }

        }
    }
}
