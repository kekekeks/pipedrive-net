using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            get { return _client.Get<List<TOrganization>>("organizations"); }
        }

        public Task<List<TOrganization>> Find(string name)
        {
            return _client.Get<List<TOrganization>>("organizations/find?term=" + name); 
        }

        JObject PrepareOrgData(string name, Dictionary<Expression<Func<TOrganization, object>>, object> extras = null)
        {
            var req = new JObject();
            req["name"] = name;
            req["visible_to"] = "3";
            return req;
        }

        public Task<TOrganization> Create(string name, Dictionary<Expression<Func<TOrganization, object>>, object> extras = null)
        {

            return _client.Post<TOrganization>("organizations", PrepareOrgData(name, extras));
        }

        public Task<TOrganization> Update(int id, string name, Dictionary<Expression<Func<TOrganization, object>>, object> extras = null)
        {
            return _client.Put<TOrganization>("organizations/" + id, PrepareOrgData(name, extras));
        }

        public Task Delete(int id)
        {
            return _client.Delete("organizations/" + id);
        }
    }
}

