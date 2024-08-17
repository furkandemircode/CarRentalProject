using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    private IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }

    public IResult Add(Rental rental)
    {
        bool rentabilityCheck = RentalAvailabilityCheck(rental.CarId);
        if (rentabilityCheck)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        return new ErrorResult(Messages.CarNotDelivered);
    }

    public IDataResult<Rental> CheckCarRentalByCarId(int carId)
    {
        var isCarAvailable = _rentalDal.Get(c => c.CarId == carId && c.ReturnDate == null);

        if (isCarAvailable != null)
        {
            return new ErrorDataResult<Rental>("Araba müsait değil kiralanmış durumda");
        }
        return new SuccessDataResult<Rental>("Kiralanabilir");

    }

    public IResult Delete(Rental rental)
    {
        _rentalDal.Delete(rental);
        return new SuccessResult();
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public IDataResult<Rental> GetById(int id)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
    }

    public IDataResult<List<RentalDetailDto>> GetRentalDetails()
    {
        return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
    }

    public IResult Update(Rental rental)
    {
        _rentalDal.Update(rental);
        return new SuccessResult();
    }

    private bool RentalAvailabilityCheck(int carId)
    {
        var rentals = _rentalDal.GetAll();
        bool isARented = rentals.Any(c => c.CarId == carId);

        if (isARented)
        {
            bool isReturnEmpty = rentals.Any(c => c.CarId == carId && c.ReturnDate == null);
            if (isReturnEmpty)
            {
                return false;
            }
        }

        return true;
    }
}
