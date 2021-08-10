using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private DbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.employers
                .Include(e => e.Category)
                .ToList();

            return View(employers);
        }
        public IActionResult Add()
        {
            List<Employer> employers = context.Employers.ToList();
            AddEmployerViewModel addEventViewModel = new AddEmployerViewModel(employers);

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer theEmployer = context.Employers.Find(addEmployerViewModel.Name);
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEmployerViewModel);
        }

        public IActionResult ProcessAddEmployerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string name = viewModel.Name;
                string location = viewModel.Location;

                Employer employer = new Employer
                {
                    Name = name,
                    Location = location
                };

                context.Employer.Add(employer);
                context.SaveChanges();

                return Redirect("/Employer/About/" + employer);
            }

            return View(viewModel);

            public IActionResult About(int id)
            {
                Employer theEmployer = context.Employers
                   .Include(e => e.Category)
                   .Single(e => e.Id == id);

                AddEmployerViewModel viewModel = new AddEmployerViewModel(theEmployer);
                return View(viewModel);
            }
        } }
}
