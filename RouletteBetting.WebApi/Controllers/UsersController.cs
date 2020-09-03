using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RouletteBetting.BusinessLogic;
using RouletteBetting.ViewModels;
using RouletteBetting.Entities.Dto;

namespace RouletteBetting.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            UserDto[] users = BusinessWebApi.GetInstance().GetUsers();

            return users;
        }

        // GET: api/Users/0
        [HttpGet]
        public UserDto Get(int userId)
        {
            UserDto user = BusinessWebApi.GetInstance().GetUser(userId);

            return user;
        }
    }
}
