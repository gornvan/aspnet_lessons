using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Xml;

namespace Routing.Controllers
{
    public class CatController : Controller
    {
        // GET: CatController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CatController/Details/5
        public ActionResult Details(int id)
        {
            var cat = new CatViewModel
            {
                BirthYear = 2020,
                Color = "White",
                Name = "Malinka",
            };
            return View(cat);
        }

        // GET: CatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
