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
    public class CloseRouletteController : ApiController
    {
        // GET: api/CloseRoulette/1
        [HttpGet]
        public IEnumerable<BetDto> CloseRoulette(int rouletteId)
        {
            BusinessWebApi.GetInstance().CloseRoulette(rouletteId, out IEnumerable<BetDto> betDtos);

            return betDtos;
        }
    }
}
