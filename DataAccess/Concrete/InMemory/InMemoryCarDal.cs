using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal : ICarDal
{
    List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>
        {
            new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 700, ModelYear = 2005, Description = "bmw f30"},
            new Car{Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 800, ModelYear = 2008, Description = "bmw e30"},
            new Car{Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 600, ModelYear = 2005, Description = "mercedes-benz E"},
        };
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(Car car)
    {
        Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

        _cars.Remove(carToDelete);
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetByCarDetailsId(int carId)
    {
        throw new NotImplementedException();
    }

    public Car GetById(int id)
    {
        Car getByCarId = _cars.SingleOrDefault(c => c.Id == id);

        return getByCarId;
    }

    public List<CarDetailDto> GetCarDetails()
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
    {
        throw new NotImplementedException();
    }

    public void Update(Car car)
    {
        Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
        carToUpdate.BrandId = car.BrandId;
        carToUpdate.ColorId = car.ColorId;
        carToUpdate.ModelYear = car.ModelYear;
        carToUpdate.Description = car.Description;
        carToUpdate.DailyPrice = car.DailyPrice;


    }
}
