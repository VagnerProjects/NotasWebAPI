using NotasWebAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Entitys
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string TipoNota { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }

        public Usuario(Guid id, string nome, int idade, DateTime? dataNascimento, string email, string celular, string tipoNota)
        {
            Endereco = new List<Endereco>();
            Id = id;
            this.Nome = nome;
            this.Idade = idade;
            this.DataNascimento = dataNascimento;
            this.Email = email;
            this.Celular = celular;
            this.TipoNota = tipoNota;
           
        }

        public void AdicionarEndereco(Endereco novoEndereco)
        {

            Endereco.Add(novoEndereco);

        }
    }
}
