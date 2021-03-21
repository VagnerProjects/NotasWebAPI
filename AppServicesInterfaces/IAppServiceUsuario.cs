using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.AppServicesInterface;
using NotasWebAPI.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.AppServicesInterfaces
{
    public interface IAppServiceUsuario: IAppService<Usuario>
    {
        Task<ServiceStatus> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> ObterUsuarioPorId(Guid Id);
    }
}
