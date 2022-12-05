using lesson6.Business.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using webServer.Areas.Cars.ViewModels;

namespace webServer.Areas.Cars
{
    [Area("Car")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(
            ICarService carService
        )
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var carsList = (await _carService.getAllCars())
                .Select(
                    cm => new CarViewModel {
                        Make = cm.Make,
                        MakeYear = cm.MakeYear,
                        TireIds = cm.Tires.Select(t => t.Id).ToList()
                        }
                ).ToList();

            var carListViewModel = new CarListViewModel
            {
                Cars = carsList,
            };

            return View(carListViewModel);
        }
    }
}
