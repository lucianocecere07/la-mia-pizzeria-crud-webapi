using LaMiaPizzeriaEFRelazione1n.DataBase;
using LaMiaPizzeriaEFRelazione1n.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeriaEFRelazione1n.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> pizze = db.Pizza.ToList();
                return Ok(pizze);
            }
        }
    }
}
