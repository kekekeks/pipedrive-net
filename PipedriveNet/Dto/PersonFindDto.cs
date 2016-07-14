using System.Collections.Generic;

namespace PipedriveNet.Dto
{
	public class PersonFindDto
	{
        public int Id { get; set; }
        public OrganizationDto OrgId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string org_name { get; set; }
        public string visible_to { get; set; }
    }

    /* TODO: Nothing */

}
