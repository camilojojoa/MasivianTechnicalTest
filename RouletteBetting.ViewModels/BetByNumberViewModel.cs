using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.ViewModels
{
    public class BetByNumberViewModel : BetViewModel
    {
        [Required, Range(0,36)]
        public byte Number { get; set; }

        public override string ToString()
        {
            string number = "Number: " + this.Number;
            return number;
        }
    }
}
