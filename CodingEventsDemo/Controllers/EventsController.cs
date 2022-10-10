using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        static private Dictionary<string, string> Events = new Dictionary<string, string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = Events;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(string name, string desc = "")
        {
            Events.Add(name, desc);
            

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event editingEvent = EventData.GetById(eventId);
            ViewBag.eventToEdit = editingEvent;
            ViewBag.title = "Edit Event " + editingEvent.Name + "(id = " + editingEvent.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            EventData editingEvent = EventData.GetById(eventId);
            editingEvent.Name = name;
            editingEvent.Description = description;
            return Redirect("/Events");
        }
    }
}
