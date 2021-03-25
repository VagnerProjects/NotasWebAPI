using NotasWebAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Domain.Entitys
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

        public Usuario(string nome, int idade, DateTime? dataNascimento, string email, string celular, string tipoNota)
        {
            Endereco = new List<Endereco>();
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

        public void AtualizarEndereco(Endereco antigoEndereco, Endereco novoEndereco)
        {
            if (!novoEndereco.Equals(antigoEndereco))
                Endereco.Add(novoEndereco);
        }
        public void DeletarEndereco(ICollection<Endereco> endereco, Guid UsuarioId)
        {
            foreach (var item in endereco)
            {
                if(item.UserId == UsuarioId)
                    Endereco.Remove(item);
            }
        }


        public string SetNome(string nome)
        {
            return this.Nome = nome;
        }

        public int SetIdade(int idade)
        {
            return this.Idade = idade;
        }

        public DateTime? SetDataNascimento (DateTime? data)
        {
            return this.DataNascimento = data;
        }

        public string SetEmail(string email)
        {
            return this.Email = email;
        }
        public string SetCelular(string celular)
        {
            return this.Celular = celular;
        }

        public string SetTipoNota(string tipoNota)
        {
            return this.TipoNota = tipoNota;
        }

    }
}
