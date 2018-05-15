namespace PipedriveNet.Dto
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public bool Done { get; set; }
        public string DueDate { get; set; }
        public string DueTime { get; set; }
    }

    /*
     
            "company_id": 340542,
            "reference_type": "none",
            "reference_id": null,
            "duration": "",
            "add_time": "2015-04-03 11:16:25",
            "marked_as_done_time": "2015-04-06 18:54:46",
            "subject": "Звонок",
            "deal_id": 1349,
            "org_id": null,
            "person_id": 1252,
            "active_flag": true,
            "update_time": "2015-04-06 18:54:52",
            "gcal_event_id": null,
            "google_calendar_id": null,
            "google_calendar_etag": null,
            "local_due_time_for_sorting": "2015-04-06 10:00:00",
            "note": "",
            "note_clean": "",
            "person_name": "Инна - ТД Морозко",
            "org_name": null,
            "deal_title": "Инна - ТД Морозко",
            "public_id": 1349,
            "assigned_to_user_id": 561847,
            "created_by_user_id": 561847,
            "owner_name": "Алексей Иванников",
            "person_dropbox_bcc": "promarket@pipedrivemail.com",
            "deal_dropbox_bcc": "promarket+deal1349@pipedrivemail.com"
     */
}
