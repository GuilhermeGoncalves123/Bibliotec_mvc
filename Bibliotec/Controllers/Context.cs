using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Bibliotec.Controllers
{
    // Classe que tera as informações do banco de dados
    public class Context : DbContext
    {
        // Criar um metodo construtor
        public Context(){

        }

        public Context(DbContextOptions<Context> options) : base (options)
        {

        }

        // onConfiguring
        // o banco de dados

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
          // colocar informacoes do banco
          // as configuracoes existem ?
          if(!optionsBuilder.IsConfigured){

            // a string de conexao do banco de dados:

            // Data Source => Nome do servidor do banco de dados

            //initial catalog => Nome do banco de dados

            //User Id e password => informacoes de acesso ao servidor do banco de dados


              optionsBuilder.UseSqlServer(@"
              Data Source=NOTE20-S28\SQLEXPRESS;
              Initial Catalog = Bibliotec_mvc;
              User Id=sa;
              Password=123;
              Integrated Security=true;
              TrustServerCertificate = true");
              
              
          }  
          
        }
        public DbSet <Categoria> Categoria {get; set;}

        public DbSet <Curso> Curso {get; set;}

        public DbSet <Livro> Livro {get; set;}

        public DbSet <Usuario> Usuario {get; set;}

        public DbSet <LivroCategoria> LivroCategoria {get; set;}

        public DbSet <LivroReserva> LivroReserva {get; set;}
    }
}