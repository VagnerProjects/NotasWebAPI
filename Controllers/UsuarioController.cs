using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.AppServices.Interface;
using NotasWebAPI.AppServices.Interfaces;
using NotasWebAPI.Models;
using NotasWebAPI.Services.Status;
using NotasWebAPI.Status;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAppServiceUsuario _appServerviceUsuario;
        public UsuarioController(IAppServiceUsuario appServerviceUsuario)
        {
            _appServerviceUsuario = appServerviceUsuario;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(UsuarioModel usuario)
        {
            try
            {
                var result = await _appServerviceUsuario.AdicionarUsuario(usuario);

                if (result.Status == 1) return BadRequest(result);

               
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceStatus(1, ex.Message+" "+ex.InnerException));
            }
        }

        [HttpGet("ObterUsuarioPorId")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid Id)
        {
            try
            {
                var result = await _appServerviceUsuario.ObterUsuarioPorId(Id);

                if (result == null) return BadRequest(new ServiceStatus(1,
                                                     "Não foi possível localizar o usuário"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceStatus(1, ex.Message+" "+ex.InnerException));
            }
        }  

        [HttpPut("AtualizarUsuario")]
        public async Task<IActionResult> AtualizarUsuario(UsuarioModel usuario)
        {
            try
            {
                var result = await _appServerviceUsuario.AtualizarUsuario(usuario);

                if (result.Status == 1) return BadRequest(result);
                                                        
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ServiceStatus(1, ex.Message + " " + ex.InnerException));
            }

        }

        [HttpDelete("DeletarUsuario")]
        public async Task<IActionResult> DeletarUsuario(Guid Id)
        {
            try
            {
                var result = await _appServerviceUsuario.DeletarUsuario(Id);

                if (result.Status == 1) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceStatus(1, ex.Message + " " + ex.InnerException));
            }
        }
    }
}
