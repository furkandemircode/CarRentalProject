using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, ExampleRentACarDbContext>, ICarDal
{
    public List<CarDetailDto> GetByCarDetailsId(int carId)
    {
        using (ExampleRentACarDbContext context = new ExampleRentACarDbContext())
        {
            var result = from c in context.Cars
                         join b in context.Brands
                         on c.BrandId equals b.Id
                         join co in context.Colors
                         on c.ColorId equals co.Id
                         where c.Id == carId
                         select new CarDetailDto
                         {
                             CarId = c.Id,
                             BrandId = b.Id,
                             ColorId = co.Id,
                             BrandName = b.Name,
                             CarName = c.Description,
                             ColorName = co.Name,
                             DailyPrice = c.DailyPrice,
                             ModelYear = c.ModelYear,
                             ImagePath =
                             (from ci in context.CarImages where c.Id == ci.CarId select ci.ImagePath).FirstOrDefault()!
                         };
            return result.ToList();
        }
    }

    public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
    {
        using (ExampleRentACarDbContext context = new ExampleRentACarDbContext())
        {
            var result = from c in context.Cars
                         join b in context.Brands
                         on c.BrandId equals b.Id
                         join co in context.Colors
                         on c.ColorId equals co.Id
                         select new CarDetailDto
                         {
                             CarId = c.Id,
                             BrandId = b.Id,
                             ColorId = co.Id,
                             BrandName = b.Name,
                             CarName = c.Description,
                             ColorName = co.Name,
                             DailyPrice = c.DailyPrice,
                             ModelYear = c.ModelYear,
                             ImagePath =
                             (from ci in context.CarImages where c.Id == ci.CarId select ci.ImagePath).FirstOrDefault()!
                         };
            return filter == null
            ? result.ToList()
            : result.Where(filter).ToList();
        }
    }

    public List<CarDetailDto> GetCarDetailsByBrandAndColor(int brandId, int colorId)
    {
        using (ExampleRentACarDbContext context = new ExampleRentACarDbContext())
        {
            var result = from c in context.Cars
                         join b in context.Brands
                         on c.BrandId equals b.Id
                         join co in context.Colors
                         on c.ColorId equals co.Id
                         where c.BrandId == brandId && c.ColorId == colorId
                         select new CarDetailDto()
                         {
                             CarId = c.Id,
                             BrandId = b.Id,
                             ColorId = co.Id,
                             BrandName = b.Name,
                             CarName = c.Description,
                             ColorName = co.Name,
                             DailyPrice = c.DailyPrice,
                             ModelYear = c.ModelYear,
                         };
            return result.ToList();
        }
    }
}





