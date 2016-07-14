using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet.Dto
{
    public class NoteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DealId { get; set; }
        public int PersonId { get; set; }
        public int OrgId { get; set; }
        public string Content{ get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public Boolean ActiveFlag { get; set; }
        public Boolean PinnedToDealFlag { get; set; }
        public Boolean PinnedToPersonFlag { get; set; }
        public Boolean PinnedToOrganisationFlag { get; set; }
    }
}

/*

   {
            "id": 1,
            "user_id": 1517885,
            "deal_id": 9,
            "person_id": 9,
            "org_id": 2,
            "content": "This is a test note",
            "add_time": "2016-07-04 16:05:22",
            "update_time": "2016-07-04 16:05:22",
            "active_flag": true,
            "pinned_to_deal_flag": false,
            "pinned_to_person_flag": false,
            "pinned_to_organization_flag": false,
            "last_update_user_id": null,
            "organization": {
                "name": "Test Partner"
            },
            "person": {
                "name": "Test Person"
            },
            "deal": {
                "title": "New Deal"
            },
            "user": {
                "email": "user@test.com",
                "name": "User Nmae",
                "icon_url": null,
                "is_you": true
            }
        }
*/
