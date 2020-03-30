using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LandisWebApp.Data;
using LandisWebApp.Models;

namespace LandisWebApp.Controllers
{
    [Route("landis")]
    public class LandisController : Controller
    {
        private readonly LandisDbContext _db;
        public LandisController(LandisDbContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index()
        {
            var meters = _db.Meters.ToArray();
            return View(meters);
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            var meter = _db.Meters.FirstOrDefault(x => x.Id == id);
            return View(meter);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(Meter meter)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _db.Meters.Add(meter);
            _db.SaveChanges();

            //TODO: implementar lógica pro caso de dar erro na hora de salvar no banco
            return RedirectToAction("Index", "Landis");
        }

        [HttpGet, Route("edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var meter = _db.Meters.FirstOrDefault(u => u.Id == id);
            return View(meter);
        }

        [HttpPost, Route("edit/{id:int}")]
        public IActionResult Edit(int id, Meter newMeter)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _db.Meters.Update(newMeter);
            _db.SaveChanges();

            //TODO: implementar lógica pro caso de dar erro na hora de salvar no banco
            return RedirectToAction("Details", "Landis",
                new { id = id });
        }

        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var meter = _db.Meters.Find((long)id);
            _db.Meters.Remove(meter);
            _db.SaveChanges();

            //TODO: implementar lógica pro caso de dar erro na hora de salvar no banco
            return RedirectToAction("Index", "Landis");
        }
    }
}