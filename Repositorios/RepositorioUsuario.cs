using Microsoft.EntityFrameworkCore;
using NotasWebAPI.Contexto;
using NotasWebAPI.Entitys;
using NotasWebAPI.RepositorioInterfaces;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Repositorios
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositoryUsuario
    {
        private CelinaDbContext ctx;
        public RepositorioUsuario()
        {
            ctx = new CelinaDbContext();
        }
        public void AdicionarUsuario(Usuario usuario)
        {
            Adicionar(usuario);
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid Id)
        {
           return await Task.FromResult(ctx.Usuario.Include(x => x.Endereco).FirstOrDefault(x => x.Id == Id));
        }
    }
}
