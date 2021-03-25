using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Status
{
    public class ServiceStatus
    {
        public int Status { get; set; }
        public string Mensagem { get; set; }

        public ServiceStatus(int status, string mensagem)
        {
            this.Status = status;
            this.Mensagem = mensagem;
        }
    }
}
