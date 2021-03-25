using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.AppServices.Interface;
using NotasWebAPI.Domain.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.AppServices.Interfaces
{
    public interface IAppServiceUsuario: IAppService<Usuario>
    {
        Task<ServiceStatus> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> ObterUsuarioPorId(Guid Id);
        Task<ServiceStatus> AtualizarUsuario(UsuarioModel usuarioModel);
        Task<ServiceStatus> DeletarUsuario(Guid Id);
    }
}
