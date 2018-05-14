using System;
using System.Collections.Generic;
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
            var request = new JObject
            {
                ["deal_id"] = dealId,
                ["type"] = type,
                ["subject"] = subject
            };

            if (due.HasValue)
            {
                request["due_date"] = due.Value.ToString("yyyy-MM-dd");
                request["due_time"] = due.Value.ToString("hh:mm");
            }

            return _client.Post<ActivityDto>("activities", request);
        }

        public Task<ActivityDto> CreateTask(int orgId, int personId, string subject, int userId, DateTime? due)
        {
            var request = new JObject
            {
                ["org_id"] = orgId,
                ["person_id"] = personId,
                ["user_id"] = userId,
                ["type"] = "task",
                [nameof(subject)] = subject
            };

            if (due.HasValue)
            {
                request["due_date"] = due.Value.ToString("yyyy-MM-dd");
                request["due_time"] = due.Value.ToString("hh:mm");
            }

            return _client.Post<ActivityDto>("activities", request);
        }

        public Task<List<ActivityDto>> GetByDeal(int dealId)
        {
            return _client.Get<List<ActivityDto>>("deals/" + dealId + "/activities?limit=9000");
        }
    }
}
