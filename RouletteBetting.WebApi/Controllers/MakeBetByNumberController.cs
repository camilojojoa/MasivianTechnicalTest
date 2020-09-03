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
    public class MakeBetByNumberController : ApiController
    {
        //POST: api/MakeBetByNumber/bet
        [HttpPost]
        public string MakeBetByNumber(BetByNumberViewModel bet)
        {
            string result = string.Empty;
            bool res = BusinessWebApi.GetInstance().MakeBetByNumber(bet);
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
