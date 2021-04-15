using AspNet.Manage.StatusCode.Application;
using AspNet.Manage.StatusCode.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Manage.StatusCode.WebApi.Controllers
{
  [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(CreateUserViewModel viewModel)
        {
            var result = _userService.Create(viewModel);

            return result.Match<IActionResult>(
                user => Ok(user),
                alreadyExist => Conflict(new {message = alreadyExist.Message }),
                internalError => Problem(internalError.Message)
            );
        }
    }
}
