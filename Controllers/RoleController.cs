using GoldStandartTestProj.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationContext context;
        public RoleController(ApplicationContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Role role)
        {
            if (role != null)
            {
                context.Roles.Add(role);
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
