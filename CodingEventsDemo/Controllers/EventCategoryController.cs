using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.AsNoTracking().ToList();
            return View(categories);
        }
    }
}
