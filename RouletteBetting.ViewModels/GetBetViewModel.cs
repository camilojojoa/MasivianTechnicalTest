using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.ViewModels
{
    public class GetBetViewModel : BetViewModel
    {
        [Display(Name = "Bet Id")]
        public int BetId { get; set; }
    }
}
