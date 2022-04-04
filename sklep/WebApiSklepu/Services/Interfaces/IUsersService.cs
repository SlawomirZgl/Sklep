using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUsersService
    {
        PaginatedData<UserDto> Get(PaginationDto dto);
        UserDto Post(PostUserDto dto);
    }
}
