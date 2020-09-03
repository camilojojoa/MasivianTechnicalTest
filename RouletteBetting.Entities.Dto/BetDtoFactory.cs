using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.Entities.Dto
{
    public enum BetBy
    {
        NUMBER = 0,
        COLOR
    }

    public class BetDtoFactory
    {
        public static BetDto FactoryMethod(int rouletteId, int userId, decimal money, BetBy betBy, byte number, Color color)
        {
            switch (betBy)
            {
                case BetBy.NUMBER:
                    return new BetByNumberDto(rouletteId, userId, money, number);
                case BetBy.COLOR:
                    return new BetByColorDto(rouletteId, userId, money, color);
                default:
                    return null;
            }
        }
    }
}
