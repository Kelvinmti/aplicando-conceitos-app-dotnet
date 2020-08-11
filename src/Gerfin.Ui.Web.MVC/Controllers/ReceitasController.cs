using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFin.ApplicationCore.DTO;
using GerFin.ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerfin.Ui.Web.MVC.Controllers
{
    public class ReceitasController : Controller
    {

        private readonly IReceitaService _receitaService;

        public ReceitasController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReceitaDTO> receitas = await _receitaService.ObterTodosAsync();

            return View(receitas);
        }

        public ActionResult NovaReceita()
        {
            return PartialView("FormCreate");
        }



        // GET: Receitas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Receitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarReceita(ReceitaDTO dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var inserido = await _receitaService.InserirAsync(dados);
                    if (inserido.ReceitaId > 0 )
                    {

                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receitas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receitas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Receitas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receitas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}