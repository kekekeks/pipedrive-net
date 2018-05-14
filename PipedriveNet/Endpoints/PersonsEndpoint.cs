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

        private JObject PreparePersonData(
            string name,
            string email,
            string phone,
            int organizationId,
            int ownerId,
            Dictionary<Expression<Func<TPerson, object>>, object> extras = null)
        {
            var person = new JObject
            {
                [nameof(name)] = name,
                ["org_id"] = organizationId,
                ["owner_id"] = ownerId
            };

            if (email != null)
                person[nameof(email)] = email;

            if (phone != null)
                person[nameof(phone)] = phone;

            if (extras != null)
            {
                foreach (var extra in extras)
                    person[_client.ResolveProperty(extra.Key)]
                        = JToken.FromObject(extra.Value, _client.Serializer);
            }

            return person;
        }

        public Task<TPerson> Create(
            string name,
            string email,
            string phone,
            int organizationId,
            int ownerId,
            Dictionary<Expression<Func<TPerson, object>>, object> extras = null)
        {
            var personData = PreparePersonData(name, email, phone, organizationId, ownerId, extras);

            return _client.Post<TPerson>("persons", personData);
        }

        public Task<TPerson> Update(
            int id,
            string name,
            string email,
            string phone,
            int organizationId,
            int ownerId,
            Dictionary<Expression<Func<TPerson, object>>, object> extras = null)
        {
            var personData = PreparePersonData(name, email, phone, organizationId, ownerId, extras);

            return _client.Put<TPerson>("persons/" + id, personData);
        }

        public Task Delete(int id)
	    {
	        return _client.Delete("persons/" + id);
	    }
	}
}
