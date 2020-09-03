using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBetting.Entities.Dto
{
    public class UserDto
    {
        private static int sequence = 0;

        [Key]
        public int UserId { get; }
        [Required]
        public string UserName { get; set; }

        public UserDto(string name)
        {
            this.UserId = sequence;
            sequence++;
            this.UserName = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is UserDto)
            {
                UserDto userDto = obj as UserDto;
                if (userDto.UserId == this.UserId)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 465150736;
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            return hashCode;
        }
    }
}
