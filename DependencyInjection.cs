using Microsoft.Extensions.DependencyInjection;
using NotasWebAPI.AppServices;
using NotasWebAPI.AppServices.Interfaces;
using NotasWebAPI.Repositorio.Interfaces;
using NotasWebAPI.Repositorios;
using NotasWebAPI.Services;
using NotasWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI
{
    public class DependencyInjection
    {
        public static void Dependencias(IServiceCollection service)
        {
            service.AddScoped<IRepositoryUsuario, RepositorioUsuario>();
            service.AddScoped<IServiceUsuario, ServiceUsuario>();
            service.AddScoped<IAppServiceUsuario, AppServiceUsuario>();
        }
    }
}
