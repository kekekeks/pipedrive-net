using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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

        public Task<TDeal> Create(string title, string value = null, string currency = null, int? personId = null,
            int? stageId = null)
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
            return _client.Post<TDeal>("deals", req);
        }
    }
}
