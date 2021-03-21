using NotasWebAPI.Base;
using NotasWebAPI.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Models
{
    public class UsuarioModel : BaseModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string TipoNota { get; set; }
        public Endereco endereco { get; set; }

        public UsuarioModel()
        {

        }
        public UsuarioModel(Guid id, string nome, int idade, DateTime? dataNascimento, string email, string celular, string tipoNota, Endereco enderecoUser)
        {
            Id = id;
            this.Nome = nome;
            this.Idade = idade;
            this.DataNascimento = dataNascimento;
            this.Email = email;
            this.Celular = celular;
            this.TipoNota = tipoNota;
            this.endereco = enderecoUser;

        
        }


    }
}
