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
    public class CreateUserController : ApiController
    {
        // GET: api/CreateUser
        [HttpGet]
        public int CreateUser(string name)
        {
            string uri = this.Request.RequestUri.ToString();
            int userId = BusinessWebApi.GetInstance().CreateNewUser(name);

            return userId;
        }
    }
}
