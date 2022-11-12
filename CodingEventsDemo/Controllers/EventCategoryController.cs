using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodingEventsDemo.Controllers
{
    public class EventsCategoryController : Controller
    {
        // Adding the data store
        private EventDbContext context;

        public EventsCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        [Route("/EventCategory/Create")]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newCategory = new()
                {
                    Name = addEventCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }
            return View("Create", addEventCategoryViewModel);
        }
    }
}
