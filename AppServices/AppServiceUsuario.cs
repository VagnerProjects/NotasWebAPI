using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.AppServicesInterfaces;
using NotasWebAPI.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.ServicesInterfaces;
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

        public AppServiceUsuario(IServiceUsuario serviceUsuario) : base(serviceUsuario)
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
    }
}
