using GoldStandartTestProj.Data;
using GoldStandartTestProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationContext context;
        public ProjectController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            

            var users = context.Users.ToList();
            ViewBag.ProjectAdmin = new SelectList(users, "Id","Email");

            var status = context.Statuses.ToList();
            ViewBag.Statuses = new SelectList(status, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (project != null)
            {
                context.Projects.Add(project);
                context.SaveChanges();
                return Redirect("~/Home/Index");
            }
            else
            {
                return Content("Что-то пошло не так!");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Project project = context.Projects.FirstOrDefault(f => f.Id == id);
            if (project != null)
            {
                var users = context.Users.ToList();
                ViewBag.ProjectAdmin = new SelectList(users, "Id", "Email");

                var status = context.Statuses.ToList();
                ViewBag.Statuses = new SelectList(status, "Id", "Name");

                return View(project);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {
            context.Projects.Update(project);
            context.SaveChanges();
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            Project project = context.Projects.FirstOrDefault(f => f.Id == id);
            if (project != null)
            {
                return View(project);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Project project = context.Projects.FirstOrDefault(f => f.Id == id);
            if (project != null)
            {
                context.Projects.Remove(project);
                context.SaveChanges();
                return Redirect("~/Home/Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
