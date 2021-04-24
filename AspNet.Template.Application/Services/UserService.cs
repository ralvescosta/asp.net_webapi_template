using AspNet.Template.Application.Interfaces;
using AspNet.Template.Domain.Entities;
using AspNet.Template.Domain.Exceptions;
using AspNet.Template.Domain.Services;
using AspNet.Template.Domain.ViewModels;
using AspNet.Template.Shared.Configurations;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Application.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly Configurations _configs;
    public UserService(IUserRepository userRepository, Configurations configs)
    {
      _userRepository = userRepository;
      _configs = configs;
    }
    public Result<User> Create(CreateUserViewModel viewModel)
    {
      var user = new User
      { 
        Name = viewModel.FirstName  + " " + viewModel.LastName,
        Age = viewModel.Age,
        Email = viewModel.Email
      };

      var result = _userRepository.Create(user);
      if(result.IsFaulted)
        return new Result<User>(new InternalErrorException());

      return result;
    }
  }
  
}
