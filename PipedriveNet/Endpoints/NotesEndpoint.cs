using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PipedriveNet.Endpoints
{
    public class NotesEndpoint
    {
        private readonly ApiClient _client;

        internal NotesEndpoint(ApiClient client)
        {
            _client = client;
        }

        public Task Create(string content, int? dealId = null, int? personId = null, int? orgId = null)
        {
            var req = new JObject();
            req["content"] = content;
            if (dealId.HasValue)
                req["deal_id"] = dealId;
            if (personId.HasValue)
                req["person_id"] = personId;
            if (orgId.HasValue)
                req["org_id"] = orgId;
            return _client.Post<object>("notes", req);
        }
    }
}
