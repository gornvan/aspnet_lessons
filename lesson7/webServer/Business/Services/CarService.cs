using DAL;
using DAL.Entities;
using lesson6.Business.Contract.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lesson6.Business.Services
{
    public class CarService : ICarService
    {
        private readonly TireServiceDBContext _dbContext;

        public CarService(
            TireServiceDBContext dbContext
        ) {
            _dbContext = dbContext;
        }

        public async Task<List<Car>> getAllCars()
        {
            return await _dbContext.Cars
                .Include(c => c.Tires) // to fetch all in just one request - include Tires
                .AsNoTracking() // a read-only request - asnotracking
                .ToListAsync();
        }
    }
}
