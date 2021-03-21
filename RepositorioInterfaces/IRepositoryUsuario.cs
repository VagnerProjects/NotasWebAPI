using NotasWebAPI.Entitys;
using NotasWebAPI.Repositorios;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.RepositorioInterfaces
{
    public interface IRepositoryUsuario: IRepository<Usuario>
    {
        void AdicionarUsuario(Usuario usuario);
        Task<Usuario> ObterUsuarioPorId(Guid Id);
    }
}
