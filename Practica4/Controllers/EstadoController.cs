using Microsoft.AspNetCore.Mvc;
using Practica4.Data;
using Practica4.Models;

namespace Practica4.Controllers
{
    public class EstadoController : Controller
    {
        private readonly AgendaDbContexc _contexc;

        public EstadoController(AgendaDbContexc contexc)
        {
            _contexc = contexc;
        }
        public IActionResult Index()
        {
            var ListEstados = _contexc.Estados.ToList();
            return View(ListEstados);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Estado estado)
        {
            if (ModelState.IsValid)
            {
                estado.CreateAt = DateTime.Now;

                _contexc.Estados.Add(estado);
                _contexc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado);
        }
    }
}
