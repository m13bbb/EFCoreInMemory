using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceRepository _repository;

        public HomeController(IServiceRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = _repository.TeamMembers.Include(a => a.Team);

            return View(model);
        }

        public IActionResult Create()
        {
            var kappa = new Team { Name = "Kappa" };

            var maju = new TeamMember { FirstName = "Bogdan", LastName = "Smalec", Team = kappa, Title = (Title)1 };

            _repository.Add(maju);

            _repository.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
