using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet.Dto
{
    public class OrganizationDto
    {
        public int OrgId { get; set; }
        public string Name { get; set; }
        public int PeopleCount { get; set; }
        public string CCEmail { get; set; }

        public int Value { set { OrgId = value; } }
    }
}
