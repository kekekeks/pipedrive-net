using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PipedriveNet.Endpoints
{
    public class PersonsEndpoint<TPerson>
    {
        private readonly ApiClient _client;

        internal PersonsEndpoint(ApiClient client)
        {
            _client = client;
        }

        public Task<List<TPerson>> All
        {
            get { return _client.Get<List<TPerson>>("persons"); }
        }

        JObject PreparePersonData(string name, string email, string phone, Dictionary<Expression<Func<TPerson, object>>, object> extras = null)
        {
            var req = new JObject();
            req["name"] = name;
            if (email != null)
                req["email"] = email;
            if (phone != null)
                req["phone"] = phone;
            if (extras != null)
                foreach (var extra in extras)
                {
                    req[_client.ResolveProperty(extra.Key)] = JToken.FromObject(extra.Value, _client.Serializer);
                }
            return req;
        }

        public Task<TPerson> Create(string name, string email, string phone, Dictionary<Expression<Func<TPerson, object>>, object> extras = null)
        {

            return _client.Post<TPerson>("persons", PreparePersonData(name, email, phone, extras));
        }

        public Task<TPerson> Update(int id, string name, string email, string phone, Dictionary<Expression<Func<TPerson, object>>, object> extras = null)
        {
            return _client.Put<TPerson>("persons/" + id, PreparePersonData(name, email, phone, extras));
        }

        public Task Delete(int id)
        {
            return _client.Delete("persons/" + id);
        }
    }
}
