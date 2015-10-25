using System.Collections.Generic;

namespace PipedriveNet.Dto
{
	public class PersonDto
	{
        public int Id { get; set; }
        public OrganizationDto OrgId { get; set; }
        public string Name { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public List<PipedriveStringListItemDto> Email { get; set; }
        public List<PipedriveStringListItemDto> Phone { get; set; }
	}

    /* TODO: Add remaining fields
     
    * id": 1,
            "company_id": 340542,
            "owner_id": {
                "id": 487920,
                "name": "Anton Aksentyuk",
                "email": "support@promarket.pro",
                "has_pic": false,
                "value": 487920
            },
    *        "org_id": null,
    *        "name": "Дмитрий",
    *        "first_name": null,
    *        "last_name": "Дмитрий",
            "open_deals_count": 0,
            "closed_deals_count": null,
            "email_messages_count": 0,
            "activities_count": null,
            "done_activities_count": null,
            "undone_activities_count": null,
            "files_count": null,
            "notes_count": 0,
            "followers_count": 1,
            "won_deals_count": 0,
            "lost_deals_count": 0,
            "active_flag": true,
     *       "phone": [
                {
                    "value": "",
                    "primary": true
                }
            ],
     *       "email": [
                {
                    "value": "",
                    "primary": true
                }
            ],
            "first_char": "д",
            "update_time": "2015-02-09 13:18:52",
            "add_time": "2015-02-09 13:18:08",
            "visible_to": "3",
            "next_activity_date": null,
            "next_activity_time": null,
            "next_activity_id": null,
            "last_activity_id": null,
            "last_activity_date": null,
            "44b58b24007b8a3ae247218ce0d0f7c475fc1514": 123,
            "org_name": null,
            "owner_name": "Anton Aksentyuk",
            "cc_email": "promarket@pipedrivemail.com",
            "im": [
                {
                    "value": "",
                    "primary": true
                }
            ]*/
}
