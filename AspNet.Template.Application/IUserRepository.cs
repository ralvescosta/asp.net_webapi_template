using AspNet.Template.Domain;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Application
{
  public interface IUserRepository
    {
        Result<User> Create(User user);
    }
}