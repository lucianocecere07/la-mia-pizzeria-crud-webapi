using LaMiaPizzeriaEFRelazione1n.DataBase;
using LaMiaPizzeriaEFRelazione1n.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LaMiaPizzeriaEFRelazione1n.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? ricerca)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> pizze = new List<Pizza>();

                if (ricerca == null || ricerca == "")
                {
                    pizze = db.Pizza.Include(pizza => pizza.Ingredienti).ToList();
                }
                else
                {
                    pizze = db.Pizza.Where(pizza => pizza.Name.ToLower().Contains(ricerca)).Include(pizza => pizza.Ingredienti).ToList();
                }

                return Ok(pizze);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDettagli(int id)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizza = db.Pizza.Where(pizza => pizza.Id == id).Include(pizza => pizza.Categoria).Include(pizza => pizza.Ingredienti).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound("Questa pizza non è stata trovata!");
                }

                return Ok(pizza);
            }
        }

    }
}
