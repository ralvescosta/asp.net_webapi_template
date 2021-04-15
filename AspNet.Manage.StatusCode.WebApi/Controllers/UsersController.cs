using AspNet.Manage.StatusCode.AppService;
using AspNet.Manage.StatusCode.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Manage.StatusCode.WebApi.Controllers
{
  [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public IActionResult Post(CreateUserViewModel viewModel)
        {
            var result = _userAppService.RegisterUser(viewModel);

            return result.Match<IActionResult>(
                user => Ok(user),
                alreadyExist => Conflict(new {message = alreadyExist.Message }),
                internalError => Problem(internalError.Message)
            );
        }
    }
}
