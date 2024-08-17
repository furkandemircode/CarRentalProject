using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
    List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
    List<CarDetailDto> GetByCarDetailsId(int carId);
    List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId);
}
