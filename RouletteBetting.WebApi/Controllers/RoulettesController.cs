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
    public class RoulettesController : ApiController
    {
        // GET: api/Roulettes
        [HttpGet]
        public IEnumerable<RouletteDto> Get()
        {
            RouletteDto[] roulettes = BusinessWebApi.GetInstance().GetRoulettes();

            return roulettes;
        }
        
        // GET: api/Roulettes/5
        [HttpGet]
        public RouletteDto Get(int rouletteId)
        {
            RouletteDto roulette = BusinessWebApi.GetInstance().GetRoulette(rouletteId);

            return roulette;
        }
        
    }
}
