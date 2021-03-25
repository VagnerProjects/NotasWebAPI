using Microsoft.EntityFrameworkCore;
using NotasWebAPI.Contexto;
using NotasWebAPI.Domain.Entitys;
using NotasWebAPI.Repositorio.Interfaces;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Repositorios
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositoryUsuario
    {
        public RepositorioUsuario()
        {
            ctx = new CelinaDbContext();
        }
        public void AdicionarUsuario(Usuario usuario)
        {
            Adicionar(usuario);
        }

        public Usuario ObterUsuarioPorId(Guid Id)
        {
           return ctx.Usuario.Include(x => x.Endereco).FirstOrDefault(x => x.Id == Id);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            Atualizar(usuario);
        }

        public void DeletarUsuario(Usuario usuario)
        {
            Excluir(x => x.Id == usuario.Id);
        }

    }
}
