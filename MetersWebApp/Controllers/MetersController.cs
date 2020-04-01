using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MetersWebApp.Data;
using MetersWebApp.Models;

namespace MetersWebApp.Controllers
{
    [Route("meters")]
    public class MetersController : Controller
    {
        //[Route("")]
        //public IActionResult Index()
        //{
        //}

        //[Route("{id:int}")]
        //public IActionResult Details(int id)
        //{
        //}

        //[HttpGet, Route("create")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost, Route("create")]
        //public IActionResult Create(Meter meter)
        //{
        //}

        //[HttpGet, Route("edit/{id:int}")]
        //public IActionResult Edit(int id)
        //{
        //}

        //[HttpPost, Route("edit/{id:int}")]
        //public IActionResult Edit(int id, Meter newMeter)
        //{
        //}

        //[Route("delete/{id:int}")]
        //public IActionResult Delete(int id)
        //{
        //    var meter = _db.Meters.Find((long)id);
        //    _db.Meters.Remove(meter);
        //    _db.SaveChanges();

        //    //TODO: implementar lógica pro caso de dar erro na hora de salvar no banco
        //    return RedirectToAction("Index", "Meters");
        //}
    }
}