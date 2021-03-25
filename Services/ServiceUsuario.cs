using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.Domain.Entitys;
using NotasWebAPI.Models;
using NotasWebAPI.Repositorio.Interfaces;
using NotasWebAPI.Services.Interfaces;
using NotasWebAPI.Services.Status;
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

            if (usuarioId != null)
                return new ServiceStatus(1, "Usuario já cadastrado!");

            if (usuarioId == null)
            {
                usuarioModel.Id = Guid.NewGuid();
                usuarioModel.endereco.Id = Guid.NewGuid();
                usuarioModel.endereco.UserId = usuarioModel.Id;
            }

            var usuario = new Usuario(usuarioModel.Id, usuarioModel.Nome, usuarioModel.Idade, usuarioModel.DataNascimento,
                                      usuarioModel.Email, usuarioModel.Celular, usuarioModel.TipoNota);
            
            usuario.AdicionarEndereco(usuarioModel.endereco);

            _repositoryUsuario.AdicionarUsuario(usuario);

            return await Task.FromResult(new ServiceStatus(0, "Usuario Cadastrado com sucesso!"));
        }

        public async Task<UsuarioModel> ObterUsuarioPorId(Guid Id)
        {
            var usuario = _repositoryUsuario.ObterUsuarioPorId(Id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            return await Task.FromResult(new UsuarioModel(usuario.Id, usuario.Nome, usuario.Idade, usuario.DataNascimento,
                                         usuario.Email, usuario.Celular, usuario.TipoNota, usuario.Endereco.FirstOrDefault()));
        }

        public async Task<ServiceStatus> AtualizarUsuario(UsuarioModel usuarioModel)
        {
            var usuario = _repositoryUsuario.ObterUsuarioPorId(usuarioModel.Id);

            if (usuario == null)
                throw new Exception("Não é possível atualizar um usuário que não está cadastrado!");

            usuarioModel.endereco.Id = Guid.NewGuid();
            usuarioModel.endereco.UserId = usuarioModel.Id;

            usuario.SetNome(usuarioModel.Nome);
            usuario.SetDataNascimento(usuarioModel.DataNascimento);
            usuario.SetIdade(usuarioModel.Idade);
            usuario.SetEmail(usuarioModel.Email);
            usuario.SetCelular(usuarioModel.Celular);
            usuario.SetTipoNota(usuarioModel.TipoNota);

       
            usuario.AtualizarEndereco(usuario.Endereco.FirstOrDefault(), usuarioModel.endereco);

            _repositoryUsuario.AtualizarUsuario(usuario);

            return await Task.FromResult(new ServiceStatus(0, "Usuário atualizado com sucesso!"));
        }

        public async Task<ServiceStatus> DeletarUsuario(Guid Id)
        {
            try
            {
                var usuario = _repositoryUsuario.ObterUsuarioPorId(Id);

                usuario.DeletarEndereco(usuario.Endereco, Id);

                _repositoryUsuario.DeletarUsuario(usuario);

                return await Task.FromResult(new ServiceStatus(0, "Usuário deletado com sucesso!"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ServiceStatus(1, ex.Message+ " "+ex.InnerException));
            }
        }
    }
}
