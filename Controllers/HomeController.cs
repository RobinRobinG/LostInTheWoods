using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInWoods.Factory;
using LostInWoods.Models;
namespace LostInWoods.Controllers
{
    public class HomeController : Controller
    {
        public readonly TrailFactory trailFactory;
        public HomeController()
        {
            trailFactory = new TrailFactory();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.alltrails = trailFactory.FindAll();
            return View();
        }

        [HttpPost("new")]
        public IActionResult NewTrail(Trail trail)
        {
            trailFactory.Add(trail);
            return RedirectToAction("Index");
        }
    }
}
