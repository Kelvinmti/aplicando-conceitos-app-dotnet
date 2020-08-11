using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerFin.ApplicationCore.DTO;
using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerFin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaService _serviceReceita;

        public ReceitasController(IReceitaService serviceReceita)
        {
            _serviceReceita = serviceReceita;
        }

        [HttpGet]
        public IEnumerable<ReceitaDTO> Get()
        {
            var todos = _serviceReceita.ObterTodos();

            return todos;
        }

        //[HttpGet]
        //public async Task<IEnumerable<ReceitaDTO>> Get()
        //{
        //    var todos = await _serviceReceita.ObterTodosAsync();

        //    return todos;
        //}

        //[HttpGet("{id}", Name = "GetById")]
        //[Route("{id:int}")]
        //public ActionResult<ReceitaDTO> Get(int id)
        //{
        //    var receita = _serviceReceita.ObterPorId(id);

        //    return receita;
        //}

        //[HttpGet("{page}", Name = "GetByPage")]
        //[Route("getbypage/{page:int}")]
        //public ActionResult<IEnumerable<ReceitaDTO>> GetByPage(int page = 1)
        //{
        //    var receitas = _serviceWrapper.Receitas.ObterPaginado(page);

        //    return _mapper.Map<List<Receita>, List<ReceitaDTO>>(receitas.ToList());
        //}

        [HttpPost]
        public ActionResult<ReceitaDTO> Post([FromBody]ReceitaDTO receitaDTO)
        {
            ReceitaDTO inserido = _serviceReceita.Inserir(receitaDTO);

            return Ok(inserido);
        }
    }
}