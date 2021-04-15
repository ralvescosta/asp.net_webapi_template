using System;
using AspNet.Manage.StatusCode.Domain;
using OneOf;

namespace AspNet.Manage.StatusCode.Application
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }
    public OneOf<User, AlreadyExisteException, InternalErrorException> Create(CreateUserViewModel viewModel)
    {
      var user = new User
      { 
        Name = viewModel.FirstName  + " " + viewModel.LastName,
        Age = viewModel.Age,
        Email = viewModel.Email
      };

      var result = _userRepository.Create(user);
      if(result.IsT1)
      {
        return (InternalErrorException)result.Value;
      }

      return (User)result.Value;
    }
  }
}
