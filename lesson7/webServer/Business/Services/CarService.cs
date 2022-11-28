using DAL.Entities;
using lesson6.Business.Contract.Interfaces;

namespace lesson6.Business.Services
{
    public class CarService : ICarService
    {
        // public for demonstration
        public readonly IRequestAccontingService _requestAccontingService;

        public static int serviceCounter = 0;
        public int thisInstanceNumber;

        public CarService(IRequestAccontingService requestAccontingService) {
            thisInstanceNumber = serviceCounter++;
            _requestAccontingService = requestAccontingService;
        }

        public List<Car> getAllCars()
        {
            throw new NotImplementedException();
        }
    }
}
