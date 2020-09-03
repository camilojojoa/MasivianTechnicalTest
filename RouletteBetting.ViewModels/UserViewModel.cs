using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.ViewModels
{
    public class UserViewModel
    {
        [Display(Name ="Id")]
        public int UserId { get; set; }
        [Required, MinLength(3), MaxLength(40), Display(Name = "Name")]
        public string UserName { get; set; }
    }
}
