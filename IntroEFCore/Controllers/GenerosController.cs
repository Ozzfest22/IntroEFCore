using AutoMapper;
using IntroEFCore.DTOs;
using IntroEFCore.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }

        [HttpPost]
        //Utilizar async cuando vamos a utilizar operaciones I.O (Operaciones en donde nuestro sistema se conecta a otros sistemas)
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion)
        {
            var existeGenero = await context.Generos.AnyAsync(g => g.Nombre == generoCreacion.Nombre);

            if (existeGenero) 
            {
                return BadRequest("Ya existe un genero con el nombre " + generoCreacion.Nombre);
            }

            var genero = mapper.Map<Genero>(generoCreacion);

            context.Add(genero);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generosCreacionDTO)
        {
            var generos = mapper.Map<Genero[]>(generosCreacionDTO);

            context.AddRange(generos);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}/nombre2")]
        public async Task<ActionResult> Put(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.Nombre = genero.Nombre + "2";

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);

            genero.Id = id;

            context.Update(genero);

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}/moderna")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAlteradas = await context.Generos.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (filasAlteradas == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id:int}/anterior")]
        public async Task<ActionResult> DeleteAnterior(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Id == id);

            if (genero == null) 
            {
                return NotFound();
            }

            context.Remove(genero);
            await context.SaveChangesAsync();

            return NoContent();

        }

    }
}
