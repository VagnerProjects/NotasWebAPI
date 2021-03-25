using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.AppServices.Interfaces;
using NotasWebAPI.Domain.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.Services;
using NotasWebAPI.Services.Interfaces;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.AppServices
{
    public class AppServiceUsuario : AppService<Usuario>, IAppServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;

        public AppServiceUsuario(IServiceUsuario serviceUsuario): base(serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
        }

        public async Task<ServiceStatus> AdicionarUsuario(UsuarioModel usuario)
        {
            if (usuario == null)
                throw new Exception("Preencha os dados do usuário!");

            var result = await _serviceUsuario.AdicionarUsuario(usuario);


            if (result.Status == 1) return await Task.FromResult(new ServiceStatus(1, "Não foi possível cadastrar o usuário, verifique os dados preenchidos."));

            return result;
        }

        public async Task<UsuarioModel> ObterUsuarioPorId(Guid Id)
        {
            return await _serviceUsuario.ObterUsuarioPorId(Id);
        }

        public async Task<ServiceStatus> AtualizarUsuario(UsuarioModel usuarioModel)
        {
            if (usuarioModel == null)
                throw new Exception("Preencha os dados do usuário!");


            var result = await _serviceUsuario.AtualizarUsuario(usuarioModel);       

            if (result.Status == 1) return await Task.FromResult(new ServiceStatus(1, "Não foi possível atualizar o usuário, verifique os dados preenchidos."));

            return result;
        }

        public async Task<ServiceStatus> DeletarUsuario(Guid Id)
        {
            return await _serviceUsuario.DeletarUsuario(Id);
        }
    }
}
