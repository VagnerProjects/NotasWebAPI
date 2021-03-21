using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.ServicesInterfaces
{
    public interface IServiceUsuario: IService<Usuario>
    {
        Task<ServiceStatus> AdicionarUsuario(UsuarioModel usuarioModel);
        Task<UsuarioModel> ObterUsuarioPorId(Guid Id);
    }
}
