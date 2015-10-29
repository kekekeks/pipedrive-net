using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Activated { get; set; }
        public string Email { get; set; }
    }
}
