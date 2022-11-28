using DAL.Entities;

namespace lesson6.Business.Contract.Interfaces
{
    public interface ICarService
    {
        public List<Car> getAllCars();
    }
}
