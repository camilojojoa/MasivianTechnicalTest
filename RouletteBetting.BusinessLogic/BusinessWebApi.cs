using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteBetting.Entities.Dto;
using RouletteBetting.ViewModels;


namespace RouletteBetting.BusinessLogic
{
    public class BusinessWebApi
    {
        private static BusinessWebApi instance = null;
        private static List<UserDto> userDtos = null;
        private static List<RouletteDto> rouletteDtos = null;
        private static List<BetDto> betDtos = null;

        private BusinessWebApi()
        {
            userDtos = new List<UserDto>();
            userDtos.Add(new UserDto("User Test"));
            rouletteDtos = new List<RouletteDto>();
            betDtos = new List<BetDto>();
        }

        public static BusinessWebApi GetInstance()
        {
            if (instance == null)
            {
                instance = new BusinessWebApi();
            }

            return instance;
        }

        public int CreateNewUser(string name)
        {
            UserDto userDto = new UserDto(name);
            userDtos.Add(userDto);

            return userDto.UserId;
        }

        public int CreateNewRoulette()
        {
            RouletteDto rouletteDto = new RouletteDto();
            rouletteDtos.Add(rouletteDto);

            return rouletteDto.RouletteId;
        }

        public RouletteDto GetRoulette(int rouletteId)
        {
            RouletteDto roulette = rouletteDtos.Find(r => r.RouletteId == rouletteId);

            return roulette;
        }

        public bool OpenRoulette(int rouletteId)
        {
            RouletteDto rouletteDto = rouletteDtos.Where(r => r.RouletteId == rouletteId).FirstOrDefault();
            if (rouletteDto == null)
            {
                return false;
            }
            rouletteDto.Status = Entities.Dto.Status.OPEN;

            return true;
        }

        public bool CloseRoulette(int rouletteId, out IEnumerable<BetDto> _betDtos)
        {
            RouletteDto rouletteDto = rouletteDtos.Where(r => r.RouletteId == rouletteId).FirstOrDefault();
            if (rouletteDto == null)
            {
                _betDtos = null;
                return false;
            }
            rouletteDto.Status = Entities.Dto.Status.CLOSED;
            _betDtos = betDtos.Where(b => b.RouletteId == rouletteId).ToList();
            //betDtos.RemoveAll(b => b.RouletteId == rouletteId);

            return true;
        }

        public bool MakeBetByNumber(BetByNumberViewModel bet)
        {
            return MakeBet(bet.RouletteId, bet.UserId, bet.Money, true, bet.Number, new Entities.Dto.Color());
        }

        public bool MakeBetByColor(BetByColorViewModel bet)
        {
            return MakeBet(bet.RouletteId, bet.UserId, bet.Money, false, 0, (Entities.Dto.Color)bet.Color);
        }

        private bool MakeBet(int rouletteId, int userId, decimal money, bool byNumber, byte number, Entities.Dto.Color color)
        {
            RouletteDto rouletteDto = rouletteDtos.Find(r => r.RouletteId == rouletteId);
            UserDto userDto = userDtos.Find(u => u.UserId == userId);
            if (rouletteDto == null || rouletteDto.Status == Entities.Dto.Status.CLOSED || userDto == null)
            {
                return false;
            }
            BetDto betDto = BetDtoFactory.FactoryMethod(rouletteId, userId, money, byNumber ? BetBy.NUMBER : BetBy.COLOR, number, color);
            betDtos.Add(betDto);

            return true;
        }

        public RouletteDto[] GetRoulettes()
        {
            RouletteDto[] roulettes = null;
            if (rouletteDtos.Count > 0)
            {
                roulettes = new RouletteDto[rouletteDtos.Count];
                rouletteDtos.CopyTo(roulettes);
            }

            return roulettes;
        }

        public UserDto[] GetUsers()
        {
            UserDto[] users = null;
            if (userDtos.Count > 0)
            {
                users = new UserDto[userDtos.Count];
                userDtos.CopyTo(users);
            }
            return users;
        }

        public UserDto GetUser(int userId)
        {
            UserDto user = userDtos.Find(u => u.UserId == userId);

            return user;
        }
    }
}
