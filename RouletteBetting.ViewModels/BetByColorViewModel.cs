using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.ViewModels
{
    public enum Color
    {
        BLACK = 0,
        RED
    }

    public class BetByColorViewModel : BetViewModel
    {
        [Required, Range(0, 1), ]
        public int Color { get; set; }

        public override string ToString()
        {
            string color = "Color: " + this.Color;
            return color;
        }
    }
}
