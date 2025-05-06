using CatalogoLivros.Application.Livros.Commands.CreateLivro;
using CatalogoLivros.Application.Livros.Commands.DeleteLivro;
using CatalogoLivros.Application.Livros.Commands.UpdateLivro;
using CatalogoLivros.Application.Livros.Queries.GetLivro;
using CatalogoLivros.Application.Livros.Queries.GetLivroById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ApiControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await Mediator.Send(new GetLivroQuery());
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livros = await Mediator.Send(new GetLivroByIdQuery() { LivroId = id });
            if (livros == null)
            {
                return NotFound();
            }
            return Ok(livros);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLivroCommand command)
        {
            var livros = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = livros.Id }, livros);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateLivroCommand command)
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
            var result = await Mediator.Send(new DeleteLivroCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
