using EventApp.Data;
using EventApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        public EventController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Event> EventList = _db.Events.ToList();
            return View(EventList);
        }

        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Add(ev);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(ev);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }

            var dbEvent = _db.Events.Find(id);
            if (dbEvent == null)
            {
                return NotFound();
            }
            
            return View(dbEvent);
        }

        [HttpPost]
        public IActionResult Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Update(ev);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(ev);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var dbEvent = _db.Events.Find(id);
            if (dbEvent == null)
            {
                return NotFound();
            }

            return View(dbEvent);
        }
        [HttpPost]
        public IActionResult DeleteFromDb(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var dbEvent = _db.Events.Find(id);
            if (dbEvent == null)
            {
                return NotFound();
            }
            _db.Events.Remove(dbEvent);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Find(string search)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(search) && Int32.TryParse(search,out id))
            {
                var foundEvent = _db.Events.Find(id);

                if (foundEvent == null)
                {
                    return RedirectToAction("Index");
                }
                
                return View(foundEvent);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}
