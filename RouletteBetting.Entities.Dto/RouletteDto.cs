using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.Entities.Dto
{
   public enum Status
    {
        CLOSED = 0,
        OPEN
    }

    public class RouletteDto : ICloneable
    {
        private static int sequenceId = 0;

        public int RouletteId { get; private set; }
        public Status Status { get; set; }
        
        public RouletteDto()
        {
            this.RouletteId = sequenceId;
            sequenceId++;
        }

        public override bool Equals(object obj)
        {
            if (obj is RouletteDto)
            {
                RouletteDto rouletteDto = obj as RouletteDto;
                if (rouletteDto.RouletteId == this.RouletteId)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -485807653;
            hashCode = hashCode * -1521134295 + RouletteId.GetHashCode();
            hashCode = hashCode * -1521134295 + Status.GetHashCode();
            return hashCode;
        }

        public object Clone()
        {
            RouletteDto obj = this.MemberwiseClone() as RouletteDto;

            return obj;
        }
    }
}
