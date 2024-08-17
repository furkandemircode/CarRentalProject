using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract;

public interface IUserService
{
    IDataResult<List<User>> GetAll();
    List<OperationClaim> GetClaims(User user);
    IDataResult<User> GetById(int id);
    IResult Add(User user);
    IResult Update(User user);
    IResult Delete(User user);
    User GetByMail(string email);
}
