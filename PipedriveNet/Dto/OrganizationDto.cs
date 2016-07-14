using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet.Dto
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PeopleCount { get; set; }
        public string CCEmail { get; set; }
        public string VisibleTo { get; set; }
        public int Value { set { Id = value; } }
    }
}
