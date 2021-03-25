using NotasWebAPI.Domain.Entitys;
using NotasWebAPI.Repositorios;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Repositorio.Interfaces
{
    public interface IRepositoryUsuario: IRepository<Usuario>
    {
        void AdicionarUsuario(Usuario usuario);
        Usuario ObterUsuarioPorId(Guid Id);
        void AtualizarUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);
    }
}
