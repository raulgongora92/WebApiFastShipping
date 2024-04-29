using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFastShipping.Context;
using Dominio.Entities;
using Dominio.Dtos;

namespace WebApiFastShipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Producto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        /*public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }*/

        public ActionResult Crear([FromBody] CrearProductoDto crearProductoDto)
        {

            Producto producto = new Producto();

            //Mapeo Manual

            //Dto - Entidad
            producto.Descripcion = crearProductoDto.Descripcion;
            producto.Categoria = crearProductoDto.Categoria;
            producto.Marca = crearProductoDto.Marca;

            producto.Estado = "Registrado";
            producto.FechaRegistro = DateTime.Now;
            producto.Codigo = producto.Categoria.Substring(0, 1) + new Random().NextInt64(1, 10000);
            _context.Productos.Add(producto);
            _context.SaveChanges();

            //Entidad - Dto
            ProductoCreadoDto productoCreadoDto = new ProductoCreadoDto();
            productoCreadoDto.Id = producto.Id;
            productoCreadoDto.FechaCreacion = producto.FechaRegistro;
            productoCreadoDto.Descripcion = producto.Descripcion;
            productoCreadoDto.Marca = producto.Marca;
            productoCreadoDto.Estado = producto.Estado;
            productoCreadoDto.Categoria = producto.Categoria;
            productoCreadoDto.Codigo = producto.Codigo;



            return Ok(productoCreadoDto);

        } 
    

            // DELETE: api/Producto/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
