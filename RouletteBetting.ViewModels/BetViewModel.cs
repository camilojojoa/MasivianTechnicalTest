using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.ViewModels
{
    public class BetViewModel
    {
        [Required, Display(Name = "User Id")]
        public int UserId { get; set; }
        [Required, Display(Name = "Roulette Id")]
        public int RouletteId { get; set; }
        [Required, Range(0, 10000)]
        public decimal Money { get; set; }
        public string Description { get; set; }
    }
}
