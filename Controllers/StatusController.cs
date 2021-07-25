using GoldStandartTestProj.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Controllers
{
    public class StatusController : Controller
    {
        private readonly ApplicationContext context;
        public StatusController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Status status)
        {
            if (status != null)
            {
                context.Statuses.Add(status);
                context.SaveChanges();
                return Redirect("~/Home/Index");
            }
            else
            {
                return Content("Что-то пошло не так!");
            }
        }
    }
}
