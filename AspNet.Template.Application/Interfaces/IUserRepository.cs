using AspNet.Template.Domain.Entities;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Application.Interfaces
{
  public interface IUserRepository
    {
        Result<User> Create(User user);
    }
}