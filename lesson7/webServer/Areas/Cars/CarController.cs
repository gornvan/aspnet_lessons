using lesson6.Business.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using webServer.Areas.Cars.ViewModels;

namespace webServer.Areas.Cars
{
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(
            ICarService carService
        )
        {
            _carService = carService;
        }


        public ActionResult Index()
        {
            var carsList = _carService.getAllCars().Select(
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
