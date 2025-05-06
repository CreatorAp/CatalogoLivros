using System.Reflection.Metadata;
using CatalogoLivros.Application.Usuarios.Commands.CreateUsuario;
using CatalogoLivros.Application.Usuarios.Commands.DeleteUsuario;
using CatalogoLivros.Application.Usuarios.Commands.UpdateUsuario;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuario;
using CatalogoLivros.Application.Usuarios.Queries.GetUsuarioById;
using CatalogoLivros.Application.Usuarios.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await Mediator.Send(new GetUsuarioQuery());
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livros = await Mediator.Send(new GetUsuarioByIdQuery() { UsuarioId = id });
            if (livros == null)
            {
                return NotFound();
            }
            return Ok(livros);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUsuarioCommand command)
        {
            var livros = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = livros.Id }, livros);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Logim(LoginQuery query)
        {
            var usuario = await Mediator.Send(query);
            
            if (usuario == null)
            {
                return Ok(usuario);
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUsuarioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteUsuarioCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
