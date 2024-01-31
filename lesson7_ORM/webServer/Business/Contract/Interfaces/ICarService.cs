using DAL.Entities;

namespace lesson6.Business.Contract.Interfaces
{
    public interface ICarService
    {
        public Task<List<Car>> getAllCars();
    }
}
