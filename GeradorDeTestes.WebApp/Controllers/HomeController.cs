﻿using Microsoft.AspNetCore.Mvc;

namespace GeradorDeTestes.WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Erro()
    {
        return View();
    }
}

