using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RouletteBetting.ViewModels
{
    public enum Status
    {
        CLOSED = 0,
        OPEN
    }

    public class RouletteViewModel
    {
        [Display(Name = "Id")]
        public int RouletteId { get; set; }
        [Display(Name = "Status")]
        public Status Status { get; set; }
    }
}
