using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newworking.Data;
using newworking.Models;

namespace newworking.Controllers
{
    public class GenreController : Controller
    {
        private readonly NewdbmvcContext dbconn;

        public GenreController()
        {
            dbconn = new NewdbmvcContext();
        }


        public async Task<IActionResult> Index()
        {
            return View(await dbconn.Genres.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre gen)
        {

            if (ModelState.IsValid)
            {
                dbconn.Genres.Add(gen);
                dbconn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }
            else
            {
                var data = await dbconn.Genres.FindAsync(id);
                return View(data);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Genre gen)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction("Index");
            }
            else
            {
                dbconn.Update(gen);
                await dbconn.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var record = await dbconn.Genres.FindAsync(id);
                dbconn.Remove(record);
                await dbconn.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
