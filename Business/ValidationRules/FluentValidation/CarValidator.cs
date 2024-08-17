using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(c => c.DailyPrice).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.ColorId).NotEmpty();
        RuleFor(c => c.ModelYear).NotEmpty();
        RuleFor(c => c.DailyPrice).GreaterThan(0);
        RuleFor(c => c.ModelYear)
            .GreaterThanOrEqualTo(1900).WithMessage("Model yılı 1900 yılından küçük olamaz.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Model yılı {DateTime.Now.Year} yılından büyük olamaz.");
        RuleFor(c => c.Description).NotEmpty();

    }
}
