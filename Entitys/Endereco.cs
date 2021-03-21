using NotasWebAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Entitys
{
    public class Endereco:EntityBase
    {
        public Guid UserId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco(Guid id,Guid userId, string logradouro, string numero, string cep, string bairro, string cidade, string estado)
        {
            this.Id = id;
            this.UserId = userId;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Cep = cep;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
        }
    }
}
