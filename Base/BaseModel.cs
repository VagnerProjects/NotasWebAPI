using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime dataDeCadastro { get; set; }
        public DateTime dataDeAlteracao { get; set; }
        public bool lixeira { get; set; }
        public string entityGuid { get; set; }

        public BaseModel()
        {
            dataDeCadastro = DataHoraBrasilia.Get();
            dataDeAlteracao = DataHoraBrasilia.Get();
            entityGuid = Guid.NewGuid().ToString();
        }

        public void EnviarParLixeira() => lixeira = true;

    }
}
