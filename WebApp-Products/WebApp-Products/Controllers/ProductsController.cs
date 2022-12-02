using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Products.Data;
using WebApp_Products.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Products.Controllers
{
    //localhost/port/api/Products
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_context.Products.Include(x => x.Category).OrderBy(x => x.Id).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Result = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                if (model != null)
                {
                    _context.Products.Add(model);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product model)
        {
            try
            {
                var Result = _context.Products.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    Result.CategoryId = model.CategoryId;
                    Result.Name = model.Name;
                    Result.Quntity = model.Quntity;
                    Result.Price = model.Price;
                    Result.Descount = model.Descount;
                    Result.Total = model.Total;

                    _context.Products.Update(Result);
                    _context.SaveChanges();
                    return Ok(Result);

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _context.Products.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    _context.Products.Remove(Result);
                    _context.SaveChanges();
                    return Ok();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
