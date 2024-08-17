using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId);
    IDataResult<List<CarDetailDto>> GetAllByColorId(int colorId);
    IDataResult<List<CarDetailDto>> GetCarDetails();
    IDataResult<List<CarDetailDto>> GetByCarDetailsId(int carId);
    IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId);
    IDataResult<Car> GetById(int id);
    IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);
}
