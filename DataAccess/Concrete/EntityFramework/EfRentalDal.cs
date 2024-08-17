using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal : EfEntityRepositoryBase<Rental, ExampleRentACarDbContext>, IRentalDal
{
    public List<RentalDetailDto> GetRentalDetails()
    {
        using (ExampleRentACarDbContext context = new ExampleRentACarDbContext())
        {
            var result = from r in context.Rentals
                         join b in context.Brands
                         on r.CarId equals b.Id
                         join u in context.Users
                         on r.CustomerId equals u.Id
                         select new RentalDetailDto
                         {
                             Id = r.Id,
                             BrandName = b.Name,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             RentDate = r.RentDate,
                             ReturnDate = r.ReturnDate,

                         };
            return result.ToList();
        }
    }
}
