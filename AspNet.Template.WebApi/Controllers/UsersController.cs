using System;
using AspNet.Template.Domain.Exceptions;
using AspNet.Template.Domain.Services;
using AspNet.Template.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Template.WebApi.Controllers
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
                user => Created("",user),
                failure => 
                {
                    switch(failure)
                    {
                        case AlreadyExisteException:
                            return Conflict();
                        case InternalErrorException:
                            return Problem();
                        default:
                            return Problem();
                    }
                }
            );
        }
    }
}
