using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IRentalService
{
    IDataResult<List<Rental>> GetAll();
    IDataResult<Rental> GetById(int id);
    IDataResult<List<RentalDetailDto>> GetRentalDetails();
    IDataResult<Rental> CheckCarRentalByCarId(int carId);
    IResult Add(Rental rental);
    IResult Update(Rental rental);
    IResult Delete(Rental rental);
}
