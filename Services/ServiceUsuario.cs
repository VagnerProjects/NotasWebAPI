using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.RepositorioInterfaces;
using NotasWebAPI.ServicesInterfaces;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Services
{
    public class ServiceUsuario : Service<Usuario>, IServiceUsuario

    {
        private readonly IRepositoryUsuario _repositoryUsuario;


        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }
        public async Task<ServiceStatus> AdicionarUsuario(UsuarioModel usuarioModel)
        {
            var usuarioId = _repositoryUsuario.Find(usuarioModel.Id);

            if (usuarioModel.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                usuarioModel.Id = Guid.NewGuid();

            if (usuarioId != null)
                throw new Exception("Usuario já cadastrado!");

            if (usuarioId == null)
                usuarioModel.Id = Guid.NewGuid();        

            usuarioModel.endereco.Id = Guid.NewGuid();
            usuarioModel.endereco.UserId = usuarioModel.Id;

            var usuario = new Usuario(usuarioModel.Id, usuarioModel.Nome, usuarioModel.Idade, usuarioModel.DataNascimento, usuarioModel.Email,
                                        usuarioModel.Celular, usuarioModel.TipoNota);


            usuario.AdicionarEndereco(usuarioModel.endereco);
            _repositoryUsuario.AdicionarUsuario(usuario);

            return await Task.FromResult(new ServiceStatus(0, "Usuario Cadastrado com sucesso!"));

        }

        public async Task<UsuarioModel> ObterUsuarioPorId(Guid Id)
        {

            var usuario = await _repositoryUsuario.ObterUsuarioPorId(Id);
          
            if (usuario == null)
                throw new Exception("Id não encontrado");

            return new UsuarioModel(usuario.Id, usuario.Nome, usuario.Idade, usuario.DataNascimento, usuario.Email, usuario.Celular, usuario.TipoNota,
                usuario.Endereco.FirstOrDefault());

        }
    }
}
