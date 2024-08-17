
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

//CarTest();

//BrandTest();

//ColorTest();

RentalTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.GetCarDetails();



    foreach (var car in result.Data)
    {
        if (result.Success)
        {
            Console.WriteLine(result.Message);
            Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.CarName + " " + car.ColorName + " " + car.DailyPrice);
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    //var result = carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 0, Description = "asd", ModelYear = 2005 });

    //if (result.Success)
    //{
    //    Console.WriteLine(result.Message);
    //}
    //else
    //{
    //    Console.WriteLine(result.Message);
    //}

}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());

    brandManager.Add(new Brand { Name = "BMW" });
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());

    colorManager.Add(new Color { Name = "Siyah" });
}

static void RentalTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());

    DateTime rentDateCarId1 = DateTime.Now;
    DateTime returnDateCarId1 = new DateTime(2024, 6, 3);

    var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = rentDateCarId1, ReturnDate = rentDateCarId1 });

    if (result.Success)
    {
        Console.WriteLine(result.Message);
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}