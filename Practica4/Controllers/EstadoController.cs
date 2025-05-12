using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                //mensaje de exito 
                TempData["mensaje"] = "El estado se ha creado correctamente";
                TempData["MessageType"] = "success";

                return RedirectToAction("Index");
            }

            //mensaje de error
            TempData["mensaje"] = "Error al crea elestado, verifica los datos";
            TempData["MessageType"] = "error";
            return View(estado);
        }
        public IActionResult Details(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var estado = _contexc.Estados.Find(id);
            if (estado == null) 
            {
                return NotFound();   
            }

            return View(estado);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var estado = _contexc.Estados.Find(id);
            if (estado == null)
            {
                return NotFound();
  
            }
            return View(estado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, Estado estado)
        {
            if (id != estado.Id)
            {
                return NotFound();
            }

            var current = _contexc.Estados.Find(id);
            if (current == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                current.Name = estado.Name;
                current.Descripcion = estado.Descripcion;
                current.Color = estado.Color;
                current.UpdateAt = DateTime.Now;

                    
                   
                    _contexc.SaveChanges();

                
                //mensaje de exito 
                TempData["mensaje"] = "El estado se ha creado correctamente";
                TempData["MessageType"] = "success";

                return RedirectToAction("Index");
            }

            //mensaje de error
            TempData["mensaje"] = "Error al crea elestado, verifica los datos";
            TempData["MessageType"] = "error";
            return View(estado);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var estado = _contexc.Estados.Find(id);
            if (estado == null)
            {
                return NotFound();
            }
            _contexc.Estados.Remove(estado);
            _contexc.SaveChanges();
            //mensaje de exito
            TempData["Message"]= "El estado se ha eliminado correctamente";
            TempData["MessageType"] = "success";
            return RedirectToAction("Index");
        }
    }
}
