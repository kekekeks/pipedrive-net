using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet.Dto
{
    public class DealDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StageId { get; set; }
        public int PipelineId { get; set; }
        public PersonIdDto PersonId { get; set; }
        public DealStatus Status { get; set; }
    }

    public enum DealStatus
    {
        Open, Won, Lost, Deleted
    }

    public class PersonIdDto
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }

    /*
     {
        "id": 1,
        "user_id": {
            "id": 487920,
            "name": "Anton Aksentyuk",
            "email": "support@promarket.pro",
            "has_pic": false,
            "value": 487920
        },
        "person_id": {
            "name": "Николай",
            "email": null,
            "phone": "",
            "value": 2
        },
        "org_id": {
            "name": "Петербуржкский Мельничный Комбинат",
            "people_count": 1,
            "cc_email": "promarket@pipedrivemail.com",
            "value": 1
        },
        "stage_id": 3,
        "title": "покупка профиля",
        "value": 4000,
        "currency": "RUB",
        "add_time": "2015-02-10 13:41:27",
        "update_time": "2015-02-10 17:09:02",
        "stage_change_time": "2015-02-10 17:09:02",
        "active": true,
        "deleted": false,
        "status": "open",
        "next_activity_date": "2015-02-10",
        "next_activity_time": null,
        "next_activity_id": 1,
        "last_activity_id": null,
        "last_activity_date": null,
        "lost_reason": null,
        "visible_to": "3",
        "close_time": null,
        "pipeline_id": 1,
        "won_time": null,
        "lost_time": null,
        "products_count": null,
        "files_count": null,
        "notes_count": 0,
        "followers_count": 1,
        "email_messages_count": null,
        "activities_count": 1,
        "done_activities_count": 0,
        "undone_activities_count": 1,
        "participants_count": 1,
        "expected_close_date": null,
        "4f56e05c527a8d4d7e584f310316d8e105eb34ac": null,
        "stage_order_nr": 4,
        "person_name": "Николай",
        "org_name": "Петербуржкский Мельничный Комбинат",
        "next_activity_subject": "Позвонить второй раз и уточнить покупку",
        "next_activity_type": "call",
        "next_activity_duration": "00:00:00",
        "next_activity_note": "",
        "formatted_value": "4 000 руб.",
        "weighted_value": 4000,
        "formatted_weighted_value": "4 000 руб.",
        "rotten_time": "2015-03-02 17:09:02",
        "owner_name": "Anton Aksentyuk",
        "cc_email": "promarket+deal1@pipedrivemail.com",
        "org_hidden": false,
        "person_hidden": false,
        "average_time_to_won": {
            "y": 0,
            "m": 0,
            "d": 0,
            "h": 0,
            "i": 0,
            "s": 0,
            "total_seconds": 0
        },
        "average_stage_progress": 0,
        "age": {
            "y": 0,
            "m": 0,
            "d": 0,
            "h": 6,
            "i": 39,
            "s": 27,
            "total_seconds": 23967
        },
        "stay_in_pipeline_stages": {
            "times_in_stages": {
                "2": 2068,
                "3": 21899
            },
            "order_of_stages": [
                3,
                2
            ]
        },
        "last_activity": null,
        "next_activity": {
            "id": 1,
            "company_id": 340542,
            "user_id": 487920,
            "done": false,
            "type": "call",
            "due_date": "2015-02-10",
            "due_time": "",
            "duration": "",
            "add_time": "2015-02-10 16:23:22",
            "marked_as_done_time": "",
            "subject": "Позвонить второй раз и уточнить покупку",
            "deal_id": 1,
            "org_id": 1,
            "person_id": 2,
            "active_flag": true,
            "update_time": "2015-02-10 16:23:22",
            "gcal_event_id": null,
            "google_calendar_id": null,
            "google_calendar_etag": null,
            "note": "",
            "person_name": "Николай",
            "org_name": "Петербуржкский Мельничный Комбинат",
            "deal_title": "покупка профиля",
            "public_id": 1,
            "assigned_to_user_id": 487920,
            "created_by_user_id": 487920,
            "owner_name": "Anton Aksentyuk",
            "person_dropbox_bcc": "promarket@pipedrivemail.com",
            "deal_dropbox_bcc": "promarket+deal1@pipedrivemail.com"
        }
    },
    "additional_data": {
        "dropbox_email": "promarket+deal1@pipedrivemail.com"
    },
    "related_objects": {
        "person": {
            "2": {
                "id": 2,
                "name": "Николай",
                "email": null,
                "phone": ""
            }
        },
        "organization": {
            "1": {
                "id": 1,
                "name": "Петербуржкский Мельничный Комбинат",
                "people_count": 1,
                "cc_email": "promarket@pipedrivemail.com"
            }
        },
        "user": {
            "487920": {
                "id": 487920,
                "name": "Anton Aksentyuk",
                "email": "support@promarket.pro",
                "has_pic": false
            }
        }
     */
}
