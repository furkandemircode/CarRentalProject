using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    [SecuredOperation("car.add,admin")]
    [ValidationAspect(typeof(CarValidator))]
    [CacheRemoveAspect("ICarService.Get")]
    public IResult Add(Car car)
    {

        _carDal.Add(car);

        return new SuccessResult(Messages.AddedCar);
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.DeletedCar);
    }

    [CacheAspect]
    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedCar);
    }

    public IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
    }

    public IDataResult<List<CarDetailDto>> GetAllByColorId(int colorId)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
    }

    public IDataResult<List<CarDetailDto>> GetByCarDetailsId(int carId)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByCarDetailsId(carId));
    }

    public IDataResult<Car> GetById(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.ListedByCarId);
    }

    public IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId)
    {

        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandAndColor(brandId, colorId));

    }

    public IDataResult<List<CarDetailDto>> GetCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDtoListed);
    }


    [ValidationAspect(typeof(CarValidator))]
    [CacheRemoveAspect("ICarService.Get")]
    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.UpdatedCar);
    }
}
