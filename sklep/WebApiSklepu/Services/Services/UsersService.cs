using Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class UsersService : IUsersService
    {
        private DataBase _database;

        public UsersService(DataBase database)
        {
            _database = database;
            if (!_database.Users.Any())
            {
                database.AddRange(new List<User>
                {
                 new User{ Name = "Imie 1", Login = "Login 1", Surname ="Surname 1", Password="Password1"}, 
                 new User{ Name = "Imie 2", Login = "Login 2", Surname ="Surname 2", Password="Password2"}, 
                 new User{ Name = "Imie 3", Login = "Login 3", Surname ="Surname 3", Password="Password3"}, 
                 new User{ Name = "Imie 4", Login = "Login 4", Surname ="Surname 4", Password="Password4"}, 
                 new User{ Name = "Imie 5", Login = "Login 5", Surname ="Surname 5", Password="Password5"}, 
                });
            }
            database.SaveChanges();
        }
        public PaginatedData<UserDto> Get(PaginationDto dto)
        {
            PaginatedData<UserDto> paginatedUser = new PaginatedData<UserDto>();
            paginatedUser.Count = _database.Users.Count();

            if (dto.SortAscending)
            {
                paginatedUser.Data = _database.Users.OrderBy(u => u.Name).Select(x => new UserDto
                {
                    Name = x.Name,
                    Id = x.Id,
                    Surname = x.Surname,
                    Login = x.Login,
                });
            }
            else
            {
                paginatedUser.Data = (IEnumerable<UserDto>)_database.Users.OrderByDescending(u => u.Name).Select(x => new UserDto
                {
                    Name = x.Name,
                    Id = x.Id,
                    Surname = x.Surname,
                    Login = x.Login,
                });
            }

            return paginatedUser;
        }

        public UserDto Post(PostUserDto dto)
        {
            _database.Users.Add(new User {Login = dto.Login, Surname = dto.Surname,
                Name = dto.Name, Password = dto.Password  });
            UserDto user = new UserDto {Id = _database.Users.LastOrDefault().Id, 
                Login = dto.Login, Name = dto.Name, Surname = dto.Surname };

            return user;
        }
    }
}
