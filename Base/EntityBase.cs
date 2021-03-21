using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Base
{
    public abstract class EntityBase 
    {
        public Guid Id { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public DateTime DataDeAlteracao { get; set; }
        public bool Lixeira { get; set; }
        public string EntityGuid { get; set; }

        public EntityBase()
        {
            DataDeCadastro = DataHoraBrasilia.Get();
            DataDeAlteracao = DataHoraBrasilia.Get();
            EntityGuid = Guid.NewGuid().ToString();
        }

        public void EnviarParLixeira() => Lixeira = true;

    }
}
