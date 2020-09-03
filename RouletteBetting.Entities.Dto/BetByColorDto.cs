using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.Entities.Dto
{
    public enum Color
    {
        BLACK = 0,
        RED
    }

    class BetByColorDto : BetDto
    {
        public Color Color { get; set; }

        internal BetByColorDto(int rouletteId, int userId, decimal money, Color color)
            :base(rouletteId, userId, money)
        {
            this.Color = Color;
        }

        public override string ToString()
        {
            string _string = "Color: " + this.Color;

            return _string;
        }
    }
}
