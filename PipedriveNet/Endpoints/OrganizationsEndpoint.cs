using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PipedriveNet.Endpoints
{
    public class OrganizationsEndpoint<TOrganization>
    {
        private readonly ApiClient _client;

        internal OrganizationsEndpoint(ApiClient client)
        {
            _client = client;
        }

        public Task<List<TOrganization>> All
        {
            get
            {
                return _client.Get<List<TOrganization>>("organizations");
            }
        }

        private JObject PrepareUserData(string name, string source, string partner, int ownerId)
        {
            return new JObject
            {
                [nameof(name)] = name,
                ["owner_id"] = ownerId,
                ["b877145c1293686c9832cac035703057a85f2fa8"] = source,
                ["5d65d158579420f6d46b7d381fad397d74778553"] = partner
            };
        }

        public Task<TOrganization> Create(string name, string source, string partner, int ownerId)
        {
            var userData = PrepareUserData(name, source, partner, ownerId);

            return _client.Post<TOrganization>("organizations", userData);
        }
    }
}
