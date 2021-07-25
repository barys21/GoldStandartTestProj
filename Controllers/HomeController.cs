using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoldStandartTestProj.Models;
using GoldStandartTestProj.Data;

namespace GoldStandartTestProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            if (context.Statuses.ToList().Count == 0 || context.Roles.ToList().Count == 0)
            {
                InitData.Create(context);
            }

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
