using GoldStandartTestProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldStandartTestProj.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly ApplicationContext context;
        public ProjectTaskController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var projects = context.Projects.ToList();
            var projectTasks = context.ProjectTasks.ToList();
            var statuses = context.Statuses.ToList();
            var roles = context.Roles.ToList();
            var users = context.Users.ToList();

            var viewModel = new ToListViewModel
            {
                Projects = projects.ToList(),
                ProjectTasks = projectTasks.ToList(),
                Statuses = statuses.ToList(),
                Roles = roles.ToList(),
                Users = users.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var users = context.Users.ToList();
            ViewBag.Users = new SelectList(users, "Id", "Email");

            var status = context.Statuses.ToList();
            ViewBag.Statuses = new SelectList(status, "Id", "Name");

            var projects = context.Projects.ToList();
            ViewBag.Projects = new SelectList(projects, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectTask projectTask)
        {
            if (projectTask != null)
            {
                //var users = context.Users.ToList();
                //ViewBag.TaskWorker = new SelectList(users, "Id", "Email");

                //var status = context.Statuses.ToList();
                //ViewBag.Statuses = new SelectList(status, "Id", "Name");

                context.ProjectTasks.Add(projectTask);
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
            ProjectTask projectTask = context.ProjectTasks.FirstOrDefault(f => f.Id == id);
            if (projectTask != null)
            {
                var users = context.Users.ToList();
                ViewBag.Users = new SelectList(users, "Id", "Email");

                var status = context.Statuses.ToList();
                ViewBag.Statuses = new SelectList(status, "Id", "Name");

                var projects = context.Projects.ToList();
                ViewBag.Projects = new SelectList(projects, "Id", "Name");

                return View(projectTask);
            }
            else
            {
                return Content("Что-то пошло не так!");
            }
        }

        [HttpPost]
        public IActionResult Edit(ProjectTask projectTask)
        {
            if (projectTask != null)
            {
                context.ProjectTasks.Update(projectTask);
                context.SaveChanges();
                return Redirect("~/Home/Index");
            }
            else
            {
                return Content("Что-то пошло не так!");
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            ProjectTask projectTask = context.ProjectTasks.FirstOrDefault(f => f.Id == id);
            if (projectTask != null)
            {
                return View(projectTask);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            ProjectTask projectTask = context.ProjectTasks.FirstOrDefault(f => f.Id == id);
            if (projectTask != null)
            {
                context.ProjectTasks.Remove(projectTask);
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
