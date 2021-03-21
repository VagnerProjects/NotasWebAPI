using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotasWebAPI.AppServicesInterface;
using NotasWebAPI.AppServicesInterfaces;
using NotasWebAPI.Models;
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

        [HttpPost("AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario(UsuarioModel usuario)
        {
            try
            {
                var result = await _appServerviceUsuario.AdicionarUsuario(usuario);

                if (result.Status == 1) return BadRequest(result);
                
                return Created("http://localhost:5002/Usuario/AdicionarUsuario",result);
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

                if (result == null) return BadRequest(new ServiceStatus(0,
                                                     "Não foi possível localizar o usuário"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceStatus(1, ex.Message+" "+ex.InnerException));
            }
        }  
    }
}
