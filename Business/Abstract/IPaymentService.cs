using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IPaymentService
{
    IResult Pay(Payment payment);
    IResult Add(Payment payment);
    IResult Update(Payment payment);
    IResult Delete(Payment payment);

    IDataResult<List<Payment>> GetAll();
    IDataResult<Payment> GetById(int id);
    IDataResult<List<Payment>> GetAllByCustomerId(int customerId);

}
