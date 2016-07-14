using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipedriveNet.Dto
{
    public class FileDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DealId { get; set; }
        public int? PersonId { get; set; }
        public int? OrgId { get; set; }
        public int? ProductId { get; set; }
        public int? EmailMessaageId { get; set; }
        public int? ActivityId { get; set; }
        public int? NoteId { get; set; }
        public int? LogId { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
    }
}

/*

    {
    "success": true,
    "data": {
       * "id": 1,
       * "user_id": 1517885,
       * "deal_id": null,
       * "person_id": 7,
        *"org_id": null,
       * "product_id": null,
       * "email_message_id": null,
       * "activity_id": null,
       * "note_id": null,
       * "log_id": null,
       * "add_time": "2016-07-03 11:52:44",
       * "update_time": "2016-07-03 11:52:42",
       * "file_name": "Step_by_Step_guide_to_set_up_Site-to-Site_VPN_using_Juniper_SSG_105935015178851467546762.docx",
       * "file_type": "docx",
       * "file_size": 520025,
        "active_flag": true,
        "inline_flag": false,
        "remote_location": "s3",
        "remote_id": "Step_by_Step_guide_to_set_up_Site-to-Site_VPN_using_Juniper_SSG.docx",
        "cid": null,
        "s3_bucket": null,
        "mail_message_id": null,
        "deal_name": null,
        "person_name": "Albert Clunknasty",
        "org_name": null,
        "product_name": null,
        "url": "https://app.pipedrive.com/api/v1/files/1/download",
        "name": "Step_by_Step_guide_to_set_up_Site-to-Site_VPN_using_Juniper_SSG.docx",
        "description": null
    }
}

*/
