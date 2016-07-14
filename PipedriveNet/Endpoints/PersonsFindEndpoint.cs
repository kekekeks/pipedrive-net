using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PipedriveNet.Endpoints
{
	public class PersonsFindEndpoint<TPersonFind>
	{
		private readonly ApiClient _client;

		internal PersonsFindEndpoint(ApiClient client)
		{
			_client = client;
		}

        public Task<List<TPersonFind>> Find(string email)
        {
            return _client.Get<List<TPersonFind>>("persons/find?term=" + Uri.EscapeDataString(email) + "&start=0&search_by_email=1");
        }

	}
}
