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
    public class CreateRouletteController : ApiController
    {
        // GET: api/CreateRoulette
        [HttpGet]
        public int Get()
        {
            int rouletteId = BusinessWebApi.GetInstance().CreateNewRoulette();

            return rouletteId;
        }
    }
}
