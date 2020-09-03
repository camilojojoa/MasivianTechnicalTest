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
    public class OpenRouletteController : ApiController
    {
        // GET: api/OpenRoulette/1
        [HttpGet]
        public string OpenRoulette(int rouletteId)
        {
            string result = string.Empty;
            bool res = BusinessWebApi.GetInstance().OpenRoulette(rouletteId);
            if (res)
            {
                result = "SUCCESS";
            }
            else
            {
                result = "NON SUCCESS";
            }

            return result;
        }
    }
}
