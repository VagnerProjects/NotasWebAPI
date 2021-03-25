using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.Domain.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Services.Interfaces
{
    public interface IServiceUsuario: IService<Usuario>
    {
        Task<ServiceStatus> AdicionarUsuario(UsuarioModel usuarioModel);
        Task<UsuarioModel> ObterUsuarioPorId(Guid Id);
        Task<ServiceStatus> AtualizarUsuario(UsuarioModel usuarioModel);
        Task<ServiceStatus> DeletarUsuario(Guid Id);
    }
}
