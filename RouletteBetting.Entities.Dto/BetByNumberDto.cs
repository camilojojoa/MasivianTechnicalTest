using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.Entities.Dto
{
    class BetByNumberDto : BetDto
    {
        public byte Number { get; set; }

        internal BetByNumberDto(int rouletteId, int userId, decimal money, byte number):
            base(rouletteId, userId, money)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            string _string = "Number: " + this.Number;

            return _string;
        }
    }
}
