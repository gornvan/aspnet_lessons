using lesson25_MVC_Angular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson25_MVC_Angular.Controllers
{
    public class HouseController : Controller
    {
        // GET: HouseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HouseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HouseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseController/Create
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

        // GET: HouseController/Edit/5
        public ActionResult Edit(int id)
        {
            // get model from DB
            var model = new HouseModel
            {
                HouseAddress = "Popowicha 10",
                HouseColor = "Brown",
                HouseId = 15
            };

            return View(model);
        }

        // GET: HouseController/Edit/5
        public JsonResult EditOnAngular(int id)
        {
            // get model from DB
            var model = new HouseModel
            {
                HouseAddress = "Popowicha 10",
                HouseColor = "Brown",
                HouseId = 15
            };

            return new JsonResult(model);
        }

        // POST: HouseController/Edit/5
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

        // GET: HouseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HouseController/Delete/5
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
