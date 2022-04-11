using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSklepu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public PaginatedData<UserDto> Get([FromQuery] PaginationDto dto)
        {
            return usersService.Get(dto);
        }

        // POST api/<UsersController>
        [HttpPost]
        public UserDto Post([FromQuery] PostUserDto dto)
        {
            return usersService.Post(dto);
        }

    }
}
