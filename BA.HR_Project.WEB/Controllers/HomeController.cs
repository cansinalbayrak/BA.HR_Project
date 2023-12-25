﻿using AutoMapper;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BA.HR_Project.WEB.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Worning()
        {
            var exception = HttpContext.Items["Exception"] as Response;
            return View(exception);
        }

        [HttpPost]
        public IActionResult Worning(Response response)
        {
            // Burada POST işlemleri gerçekleştirilebilir.
            // Örneğin, loglama veya başka bir işlem yapılabilir.

            return RedirectToAction("Index"); // Veya başka bir sayfaya yönlendirme yapılabilir.
        }
    }
}