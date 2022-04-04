using Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class AuthorizationService : IAuthorizationService
    {
        private DataBase _database;

        public AuthorizationService(DataBase database)
        {
            _database = database;
        }

        public int Login(AuthorizationDto dto)
        {
            return _database.Users.Where(u => 
            (u.Login == dto.Login && u.Password == dto.Password))
                .FirstOrDefault().Id;
        }
    }
}
