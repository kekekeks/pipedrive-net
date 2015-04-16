using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PipedriveNet.Dto;

namespace PipedriveNet.Endpoints
{
    public class ActivitesEndpoint
    {
        private readonly ApiClient _client;

        internal ActivitesEndpoint(ApiClient client)
        {
            _client = client;
        }
        
        public Task Delete(int id)
        {
            return _client.Delete("activities/" + id);
        }

        public Task<ActivityDto> Create(int dealId, string type, string subject, DateTime? due)
        {
            var req = new JObject();
            req["deal_id"] = dealId;
            req["type"] = type;
            req["subject"] = subject;
            if (due.HasValue)
            {
                req["due_date"] = due.Value.ToString("yyyy-MM-dd");
                req["due_time"] = due.Value.ToString("hh:mm");
            }
            return _client.Post<ActivityDto>("activities", req);
        }

        public Task<List<ActivityDto>> GetByDeal(int dealId)
        {
            return _client.Get<List<ActivityDto>>("deals/" + dealId + "/activities?limit=9000");
        }
    }
}
