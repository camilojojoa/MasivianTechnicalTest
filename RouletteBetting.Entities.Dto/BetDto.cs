using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.Entities.Dto
{
    public abstract class BetDto
    {
        private static int sequenceId = 0;
        public int BetId { get; private set; }
        public int UserId { get; set; }
        public int RouletteId { get; set; }
        public decimal Money { get; set; }
        public string Description { get => this.ToString(); }

        internal BetDto(int rouletteId, int userId, decimal money)
        {
            this.BetId = sequenceId;
            sequenceId++;
            this.RouletteId = rouletteId;
            this.UserId = userId;
            this.Money = money;
        }

        public override bool Equals(object obj)
        {
            if (obj is BetDto)
            {
                BetDto betDto = obj as BetDto;
                if (betDto.BetId == this.BetId)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1420814300;
            hashCode = hashCode * -1521134295 + BetId.GetHashCode();
            hashCode = hashCode * -1521134295 + RouletteId.GetHashCode();
            hashCode = hashCode * -1521134295 + Money.GetHashCode();
            return hashCode;
        }
    }
}
