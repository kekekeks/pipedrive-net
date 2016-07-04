using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PipedriveNet.Dto;

namespace PipedriveNet.Endpoints
{
    public class DealsEndpoint <TDeal>
    {
        private readonly ApiClient _client;

        internal DealsEndpoint(ApiClient client)
        {
            _client = client;
        }

        public Task<List<TDeal>> All { get { return _client.Get<List<TDeal>>("deals"); } }

        public Task<TDeal> GetById(int id)
        {
            return _client.Get<TDeal>("deals/" + id);
        }

        public Task<List<TDeal>> GetByPersonId(int personId, DealStatus? status = null)
        {
            var ep = "persons/" + personId + "/deals";
            var qs = new QueryString() {{"limit", "9000"}};
            if (status != null)
                qs["status"] = status.ToString().ToLower();
            ep += qs;
            return _client.Get<List<TDeal>>(ep);
        }


        public Task<TDeal> Create(string title, string value = null, string currency = null, int? personId = null,
            int? stageId = null, int? userId = null, int? orgId = null)
        {
            var req = new JObject();
            req["title"] = title;
            if (value != null)
                req["value"] = value;
            if (currency != null)
                req["currency"] = currency;
            if (personId != null)
                req["person_id"] = personId;
            if (stageId != null)
                req["stage_id"] = stageId;
            if (userId != null)
                req["user_id"] = userId;
            if (orgId != null)
                req["org_id"] = orgId;
            return _client.Post<TDeal>("deals", req);
        }

        public Task<TDeal> Update(int id, string title = null, DealStatus? status = null, int? stageId = null, string value = null)
        {
            var req = new JObject();
            if (title != null)
                req["title"] = title;
            if (status != null)
                req["status"] = status.ToString().ToLower();
            if (stageId != null)
                req["stage_id"] = stageId;
            if (value != null)
                req["value"] = value;
           return _client.Put<TDeal>("deals/" + id, req);
        }

        public Task<TDeal> Merge(int id, int mergeWith)
        {
            return _client.Put<TDeal>("deals/" + id + "/duplicate", new {MergeWithId = mergeWith});
        }

        public Task Delete(int id)
        {
            return _client.Delete("deals/" + id);
        }
    }
}
