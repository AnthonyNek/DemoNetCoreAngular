using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Modelos;

namespace WebApi.Controllers
{
    [Route("Productos")]
    [EnableCors("MyPolicy")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly BDPruebaContext _context;

        public ProductosController(BDPruebaContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        [Route("ListarProductos")]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet()]
        [Route("ObtenerProductos/{id}")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut()]
        [Route("ActualizarProducto/{id}")]
        public async Task<IActionResult> PutProductos(int id, Productos productos)
        {
            if (id != productos.Id)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("GuardarProductos")]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
          var resultado=  await _context.SaveChangesAsync();
            if(resultado==1)
            {
                return Ok(new { resultado = "0000", Descripcion = "Transaccion exitosa" });
            }
            else
            {
                return BadRequest(new { resultado = "1111", Descripcion = "Error al procesar la transaccion" });
            }

        }

        // DELETE: api/Productos/5
        [HttpDelete()]
        [Route("EliminarProductos/{id}")]
        public async Task<ActionResult<Productos>> DeleteProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productos);
            var resultado = await _context.SaveChangesAsync();
            if(resultado==1)
            {
                return Ok(new { resultado = "0000", Descripcion = "Transaccion exitosa" });
            }
            else
            {
                return BadRequest(new { resultado = "1111", Descripcion = "Error al procesar transacción" });
            }
           
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
