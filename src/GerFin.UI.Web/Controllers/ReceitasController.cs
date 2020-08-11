using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFin.ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerFin.UI.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReceitasController : Controller
    {
        private readonly IReceitaService _receitaService;

        public ReceitasController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable> Get()
        {
            var receitas = _receitaService.ObterTodos();

            return receitas.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
